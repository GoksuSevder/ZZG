using System;
using System.Collections.Generic;
using System.Text;
using ZZG.Entities;

namespace ZZG.DataAccess.Abstract
{
    public interface IProductDal : IGenericRepository<Product>
    {
        IEnumerable<Product> GetPopulerProducts();
        List<Product> GetProductsByCategory(string category,int page,int pageSize);
        Product GetProductDetails(int id);
        int GetCountByCategory(string category);
        Product GetProductWithCategories(int id);
        void Update(Product entity, int[] categoryIds);
    }
}
