using Core.Utilities.Results.Abstract;
using ShopApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
    public interface IAuthenticationService
    {
        Task<IResult> LoginWithEmailAsync(LoginDtoWithEmail loginDto);
        Task<IResult> LoginWithPhoneNumberAsync(LoginDtoWithPhoneNumber loginDto);
        Task<IDataResult<TokenDto>> CreateTokenByEmailAsync(LoginDtoWithEmail loginDto);
        Task<IDataResult<TokenDto>> CreateTokenByPhoneNumberAsync(LoginDtoWithPhoneNumber loginDto);
        Task<IResult> RevokeRefreshToken(string refreshToken);
    }
}
