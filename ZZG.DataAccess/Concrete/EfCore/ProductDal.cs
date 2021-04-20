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
        public int GetCountByCategory(string category)
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
                return products.Count();
            }
        }

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

        public Product GetProductWithCategories(int id)
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

        public void Update(Product entity, int[] categoryIds)
        {
            using (var context = new ZZGContext())
            {
                var product = context.Products
                    .Include(i => i.ProductCategories)
                    .FirstOrDefault(i=>i.Id==entity.Id);
                if (product!=null)
                {
                    product.Name = entity.Name;
                    product.ImageUrl = entity.ImageUrl;
                    product.Description = entity.Description;
                    product.Price = entity.Price;
                    product.ProductCategories = categoryIds.Select(catId => new ProductCategory()
                    {
                        CategoryId = catId,
                        ProductId = product.Id
                    }).ToList();
                    context.SaveChanges();
                }
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
