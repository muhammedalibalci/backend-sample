using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Service.Abstract;
using Service.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Concrete
{
    public class UserService: IUserService
    {
        private IUserDal _userDal;
        public UserService(IUserDal _userDal)
        {
            this._userDal = _userDal;
        }



        public IDataResult<User> Get(int id)
        {
            var user = _userDal.Get(x => x.Id == id);
            if (user != null)
            {
                return new SuccessDataResult<User>(user);
            }
            return new ErrorDataResult<User>(Messages.Get);
        }

        public IDataResult<List<User>> GetList()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetList().ToList());
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessDataResult<User>(Messages.Added);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessDataResult<Comment>(Messages.Deleted);
        }
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessDataResult<Comment>(Messages.Updated);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(x => x.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}
