using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstract
{
   public interface IUserService
    {
        IDataResult<List<User>> GetList();
        IDataResult<User> Get(int id);
        User GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
    }
}
