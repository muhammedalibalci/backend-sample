using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstract
{
    public interface ICommentService
    {
        IDataResult<List<Comment>> GetList();
        IDataResult<Comment> Get(int id);

        IResult Add(Comment comment);
        IResult Delete(Comment comment);
        IResult Update(Comment comment);
    }
}
