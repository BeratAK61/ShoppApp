using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using ShopApp.Business.Abstract;
using ShopApp.Business.Utilities;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Concrete
{
    public class UserRefreshTokenManager : IUserRefreshTokenService
    {
        private readonly IUserRefreshTokenDal _userRefreshTokenDal;

        public UserRefreshTokenManager(IUserRefreshTokenDal userRefreshTokenDal)
        {
            _userRefreshTokenDal = userRefreshTokenDal;
        }

        public IDataResult<UserRefreshToken> Create(UserRefreshToken entity)
        {
            if (entity != null)
            {
                _userRefreshTokenDal.Create(entity);
                return new SuccessDataResult<UserRefreshToken>(entity, Messages.AddingCompleted);
            }
            return new ErrorDataResult<UserRefreshToken>(entity, Messages.AddingNotCompleted);
        }

        public IResult Delete(UserRefreshToken entity)
        {
            if (entity != null)
            {
                _userRefreshTokenDal.Delete(entity);
                return new SuccessResult(Messages.DeletingCompleted);
            }
            return new ErrorResult(Messages.DeletingNotCompleted);
        }

        public IDataResult<List<UserRefreshToken>> GetAll()
        {
            var userRefreshTokens = _userRefreshTokenDal.GetAll();
            if (userRefreshTokens != null)
            {
                return new SuccessDataResult<List<UserRefreshToken>>(userRefreshTokens, Messages.ListingCompleted);
            }
            return new ErrorDataResult<List<UserRefreshToken>>(Messages.ListingNotCompleted);
        }

        public IDataResult<UserRefreshToken> GetById(int? id)
        {
            if (id != null)
            {
                var userRefreshToken = _userRefreshTokenDal.Get(u => u.Id == (int)id);
                if (userRefreshToken != null)
                {
                    return new SuccessDataResult<UserRefreshToken>(userRefreshToken, Messages.GettingCompleted);
                }
                return new ErrorDataResult<UserRefreshToken>(Messages.GettingNotCompleted);
            }
            return new ErrorDataResult<UserRefreshToken>(Messages.GettingNotCompleted);
        }

        public IDataResult<UserRefreshToken> GetByRefreshToken(string refreshToken)
        {
            return new SuccessDataResult<UserRefreshToken>(_userRefreshTokenDal.Get(t => t.Code == refreshToken), Messages.TokenFound);
        }

        public IDataResult<UserRefreshToken> GetByUserId(string userId)
        {
            var userRefreshToken = _userRefreshTokenDal.Get(u => u.UserId == userId);
            if (userRefreshToken != null)
            {
                return new SuccessDataResult<UserRefreshToken>(userRefreshToken, Messages.TokenFound);
            }
            return new ErrorDataResult<UserRefreshToken>(Messages.TokenNotFound);
        }

        public IDataResult<string> GetUserIdByRefreshToken(string refreshToken)
        {
            return new SuccessDataResult<string>(_userRefreshTokenDal.Get(r => r.Code == refreshToken).UserId);
        }

        public IResult Update(UserRefreshToken entity)
        {
            if (entity != null)
            {
                _userRefreshTokenDal.Update(entity);
                return new SuccessResult(Messages.UpdatingCompleted);
            }
            return new ErrorResult(Messages.UpdatingNotCompleted);
        }
    }
}
