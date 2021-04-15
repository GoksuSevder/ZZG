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

        List<Product> IProductDal.GetProductsByCategory(string category,int page,int pageSize)
        {
            using (var context = new ZZGContext())
            {
                var products = context.Products.AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategories.Any(a => a.Category.Name.ToLower() == category.ToLower()));                        
                }
                return products.Skip((page-1)*pageSize).Take(pageSize).ToList();
            }
        }
    }
}
