using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopApp.Business.Abstract;
using ShopApp.Business.Utilities;
using ShopApp.Entities.Concrete;
using ShopApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Concrete
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IUserRefreshTokenService _userRefreshTokenService;
        public AuthenticationManager(UserManager<User> userManager, ITokenService tokenService, IUserRefreshTokenService userRefreshTokenService, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _userRefreshTokenService = userRefreshTokenService;
            _signInManager = signInManager;
        }

        public async Task<IResult> LoginWithEmailAsync(LoginDtoWithEmail loginDto)
        {
            if (loginDto != null)
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                if (user != null)
                {
                    if (user.EmailConfirmed)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
                        if (result.Succeeded)
                        {
                            return new SuccessResult(Messages.LoginSuccess);
                        }
                        return new ErrorResult(Messages.LoginError);
                    }
                    return new ErrorResult(Messages.EmailNotConfirmed);
                }
                return new ErrorResult(Messages.LoginError);
            }
            return new ErrorResult(Messages.LoginError);
        }

        public async Task<IResult> LoginWithPhoneNumberAsync(LoginDtoWithPhoneNumber loginDto)
        {
            if (loginDto != null)
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == loginDto.PhoneNumber);
                if (user != null)
                {
                    if (user.EmailConfirmed)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
                        if (result.Succeeded)
                        {
                            return new SuccessResult(Messages.LoginSuccess);
                        }
                        return new ErrorResult(Messages.LoginError);
                    }
                    return new ErrorResult(Messages.EmailNotConfirmed);
                }
                return new ErrorResult(Messages.LoginError);
            }
            return new ErrorResult(Messages.LoginError);
        }

        public async Task<IDataResult<TokenDto>> CreateTokenByEmailAsync(LoginDtoWithEmail loginDto)
        {
            if (loginDto != null)
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                if (user != null)
                {
                    if (await _userManager.CheckPasswordAsync(user, loginDto.Password))
                    {
                        var token = _tokenService.CreateToken(user);

                        var result = _userRefreshTokenService.GetByUserId(user.Id);

                        if (result.Success)  //Yani refresh token varsa
                        {
                            result.Data.Code = token.Data.RefreshToken;
                            result.Data.Expiration = token.Data.RefreshTokenExpiration;
                            _userRefreshTokenService.Update(result.Data);
                            return new SuccessDataResult<TokenDto>(token.Data, Messages.LoginSuccess);
                        }
                        else  //Yani refresh token yoksa
                        {
                            var newRefreshTokenResult = new UserRefreshToken
                            {
                                UserId = user.Id,
                                Code = token.Data.RefreshToken,
                                Expiration = token.Data.RefreshTokenExpiration
                            };
                            var secondResult = _userRefreshTokenService.Create(newRefreshTokenResult);
                            _userRefreshTokenService.Update(newRefreshTokenResult);
                            return new SuccessDataResult<TokenDto>(token.Data, Messages.LoginSuccess);
                        }
                    }
                    return new ErrorDataResult<TokenDto>(Messages.LoginError);
                }
                return new ErrorDataResult<TokenDto>(Messages.LoginError);
            }
            return new ErrorDataResult<TokenDto>(Messages.LoginError);
        }

        public async Task<IDataResult<TokenDto>> CreateTokenByPhoneNumberAsync(LoginDtoWithPhoneNumber loginDto)
        {
            if (loginDto != null)
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == loginDto.PhoneNumber);
                if (user != null)
                {
                    if (await _userManager.CheckPasswordAsync(user, loginDto.Password))
                    {
                        var token = _tokenService.CreateToken(user);

                        var result = _userRefreshTokenService.GetByUserId(user.Id);

                        if (result.Success)  //Yani refresh token varsa
                        {
                            result.Data.Code = token.Data.RefreshToken;
                            result.Data.Expiration = token.Data.RefreshTokenExpiration;
                            _userRefreshTokenService.Update(result.Data);
                            return new SuccessDataResult<TokenDto>(token.Data, Messages.LoginSuccess);
                        }
                        else  //Yani refresh token yoksa
                        {
                            var newRefreshTokenResult = new UserRefreshToken
                            {
                                UserId = user.Id,
                                Code = token.Data.RefreshToken,
                                Expiration = token.Data.RefreshTokenExpiration
                            };
                            var secondResult = _userRefreshTokenService.Create(newRefreshTokenResult);
                            _userRefreshTokenService.Update(newRefreshTokenResult);
                            return new SuccessDataResult<TokenDto>(token.Data, Messages.LoginSuccess);
                        }
                    }
                    return new ErrorDataResult<TokenDto>(Messages.LoginError);
                }
                return new ErrorDataResult<TokenDto>(Messages.LoginError);
            }
            return new ErrorDataResult<TokenDto>(Messages.LoginError);
        }

        public async Task<IResult> RevokeRefreshToken(string refreshToken)
        {
            var existRefreshToken = _userRefreshTokenService.GetByRefreshToken(refreshToken);
            if (existRefreshToken.Data != null)
            {
                var user = await _userManager.FindByIdAsync(_userRefreshTokenService.GetUserIdByRefreshToken(refreshToken).Data);
                await _userManager.UpdateAsync(user);
                _userRefreshTokenService.Delete(existRefreshToken.Data);
                return new SuccessResult(Messages.TokenDeletingCompleted);
            }
            return new ErrorDataResult<TokenDto>(Messages.TokenNotFound);
        }
    }
}
