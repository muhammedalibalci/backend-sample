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
    public class CommentService : ICommentService
    {
        private ICommentDal _commentDal;
        public CommentService(ICommentDal _commentDal)
        {
            this._commentDal = _commentDal;
        }

      

        public IDataResult<Comment> Get(int id)
        {
            var comment = _commentDal.Get(x=>x.Id==id);
            if (comment != null)
            {
                return new SuccessDataResult<Comment>(comment);
            }
            return new ErrorDataResult<Comment>(Messages.Get);
        }

        public IDataResult<List<Comment>> GetList()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetList().ToList());
        }
        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessDataResult<Comment>(Messages.Added);
        }

        public IResult Delete(Comment comment)
        {
            _commentDal.Delete(comment);
            return new SuccessDataResult<Comment>(Messages.Deleted);
        }
        public IResult Update(Comment comment)
        {
            _commentDal.Update(comment);
            return new SuccessDataResult<Comment>(Messages.Updated);
        }
    }
}
