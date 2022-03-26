using Core.Configuration;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ShopApp.Business.Abstract;
using ShopApp.Business.Helpers;
using ShopApp.Business.Utilities;
using ShopApp.Entities.Concrete;
using ShopApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Concrete
{
    public class TokenManager : ITokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly CustomTokenOption _tokenOption;
        public TokenManager(UserManager<User> userManager, CustomTokenOption tokenOption)
        {
            _userManager = userManager;
            _tokenOption = tokenOption;
        }

        public IDataResult<TokenDto> CreateToken(User user)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOption.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddMinutes(_tokenOption.RefreshTokenExpiration);

            var securityKey = SignService.GetSymetricSecurityKey(_tokenOption.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);


            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenOption.Issuer,
                expires: accessTokenExpiration,
                notBefore:DateTime.Now,
                claims:GetClaims(user,_tokenOption.Audience),
                signingCredentials:signingCredentials);

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            var tokenDto = new TokenDto
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken(),
                AccessTokenExpiration = accessTokenExpiration,
                RefreshTokenExpiration = refreshTokenExpiration
            };


            return new SuccessDataResult<TokenDto>(tokenDto, Messages.CreatingTokenCompleted);
        }

        private IEnumerable<Claim> GetClaims(User user, List<string> audiences)
        {
            //Aslinda token'in payload kisminda olmasi gerekenler
            var userList = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var userRoles = _userManager.GetRolesAsync(user).Result.ToList();

            for (int i = 0; i <= userRoles.Count - 1; i++)
            {
                userList.Add(new Claim(ClaimTypes.Role, userRoles[i]));
            }

            userList.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

            return userList;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];

            using var rnd = RandomNumberGenerator.Create();  //Cozulmesi cok cok dusuk olan bir byte urettik

            rnd.GetBytes(numberByte);

            return Convert.ToBase64String(numberByte);
        }

    }
}
