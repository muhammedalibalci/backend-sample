using Core.DataAccess.Concrete;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class PostDal : EfEntityRepositoryBase<Post, EfDbContext>, IPostDal
    {
    }
}
