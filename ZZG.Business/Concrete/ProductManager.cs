using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZZG.Business.Abstract;
using ZZG.DataAccess.Abstract;
using ZZG.Entities;

namespace ZZG.Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Create(Product entity)
        {
            _productDal.Create(entity);
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll().ToList();
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public int GetCountByCategory(string category)
        {
            return _productDal.GetCountByCategory(category);
        }

        public List<Product> GetPopulerProducts()
        {
            return _productDal.GetAll(p => p.Price > 2000).ToList();
        }

        public Product GetProductDetails(int id)
        {
            return _productDal.GetProductDetails(id);
        }

        public List<Product> GetProductsByCategory(string category,int page,int pageSize)
        {
            return _productDal.GetProductsByCategory(category,page, pageSize);
        }

        public Product GetProductWithCategories(int id)
        {
            return _productDal.GetProductWithCategories(id);
        }

        public void Update(Product entity, int[] categoryIds)
        {
            _productDal.Update(entity,categoryIds);
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
