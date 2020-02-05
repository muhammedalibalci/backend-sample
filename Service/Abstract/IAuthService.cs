using Core.Entities.Concrete;
using Core.Entities.Dto;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
