using System;
using System.Collections.Generic;
using System.Text;
using ZZG.DataAccess.Abstract;
using ZZG.Entities;

namespace ZZG.DataAccess.Concrete.EfCore
{
    public class ProductDal : GenericRepository<Product, ZZGContext>, IProductDal
    {
        public IEnumerable<Product> GetPopulerProducts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
