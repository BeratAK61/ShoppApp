using Core.Utilities.Results.Abstract;
using ShopApp.Entities.Concrete;
using ShopApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
    public interface ITokenService
    {
        IDataResult<TokenDto> CreateToken(User user);
    }
}
