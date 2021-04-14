﻿using System;
using System.Collections.Generic;
using System.Text;
using ZZG.Entities;

namespace ZZG.Business.Abstract
{
    public interface IProductService 
    {
        Product GetById(int id);
        Product GetProductDetails(int id);
        List<Product> GetAll();
        List<Product> GetPopulerProducts();
        void Create(Product entity);
        void Delete(Product entity);
        void Update(Product entity);
    }
}
