using System;
using System.Collections.Generic;
using System.Text;
using ZZG.DataAccess.Abstract;
using ZZG.Entities;

namespace ZZG.DataAccess.Concrete.EfCore
{
   public class CategoryDal : GenericRepository<Category,ZZGContext>, ICategoryDal
    {
    }
}
