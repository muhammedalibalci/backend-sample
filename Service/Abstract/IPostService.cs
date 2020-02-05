using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstract
{
    public interface IPostService
    {
        IDataResult<List<Post>> GetList();
        IDataResult<Post> Get(int id);
        IResult Add(Post post);
        IResult Delete(int id);
        IResult Update(Post post);
    }
}
