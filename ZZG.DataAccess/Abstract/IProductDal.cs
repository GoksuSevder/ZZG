using System;
using System.Collections.Generic;
using System.Text;
using ZZG.Entities;

namespace ZZG.DataAccess.Abstract
{
    public interface IProductDal : IGenericRepository<Product>
    {
        IEnumerable<Product> GetPopulerProducts { get; set; }
    }
}
