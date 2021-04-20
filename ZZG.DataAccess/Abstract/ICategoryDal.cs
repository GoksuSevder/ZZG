using System;
using System.Collections.Generic;
using System.Text;
using ZZG.Entities;

namespace ZZG.DataAccess.Abstract
{
    public interface ICategoryDal : IGenericRepository<Category>
    {
        Category GetByIdWithProducts(int id);
        void DeleteFromCategory(int categoryId, int productId);
    }
}
