using Core.Utilities.Results.Abstract;
using ShopApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
    public interface IUserRefreshTokenService
    {
        IDataResult<UserRefreshToken> Create(UserRefreshToken entity);
        IResult Delete(UserRefreshToken entity);
        IResult Update(UserRefreshToken entity);
        IDataResult<List<UserRefreshToken>> GetAll();
        IDataResult<UserRefreshToken> GetById(int? id);
        IDataResult<UserRefreshToken> GetByUserId(string userId);
        IDataResult<UserRefreshToken> GetByRefreshToken(string refreshToken);
        IDataResult<string> GetUserIdByRefreshToken(string userId);
    }
}
