using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZZG.DataAccess.Abstract;
using ZZG.Entities;

namespace ZZG.DataAccess.Concrete.EfCore
{
    public class ProductDal : GenericRepository<Product, ZZGContext>, IProductDal
    {
        public IEnumerable<Product> GetPopulerProducts()
        {
            throw new NotImplementedException();
        }
        public Product GetProductDetails(int id)
        {
            using (var contex = new ZZGContext())
            {
                return contex.Products
                    .Where(i => i.Id == id)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefault();
            }
        }
    }
}
