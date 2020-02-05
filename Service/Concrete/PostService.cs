
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using FluentValidation;
using Service.Abstract;
using Service.Constants;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Concrete
{
    public class PostService : IPostService
    {
        public IPostDal _postDal;
        public PostService(IPostDal _postDal)
        {
            this._postDal = _postDal;
        }

        public IDataResult<Post> Get(int id)
        {
            var result = _postDal.Get(x => x.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<Post>(_postDal.Get(x => x.Id == id));
            }

            return new ErrorDataResult<Post>(result, Messages.Get);
        }

        public IDataResult<List<Post>> GetList()
        {
            return new SuccessDataResult<List<Post>>(_postDal.GetList().ToList());
        }
     
        public IResult Add(Post post)
        {
            if (!String.IsNullOrEmpty(post.Content))
            {
                _postDal.Add(post);
                return new SuccessResult(Messages.Added);
            }
            return new ErrorResult(Messages.DeleteError);
        }

        public IResult Delete(int id)
        {
            var post = _postDal.Get(x => x.Id == id);
            if (post != null)
            {
                _postDal.Delete(post);
                return new SuccessResult(Messages.Deleted);
            }
            return new ErrorResult(Messages.DeleteError);
        }

        public IResult Update(Post post)
        {
            if (!String.IsNullOrEmpty(post.Content))
            {
                _postDal.Update(post);
                return new SuccessResult(Messages.Updated);
            }
            return new ErrorResult(Messages.UpdateError);
        }
    }
}
