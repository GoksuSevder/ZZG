using System;
using System.Collections.Generic;
using System.Text;

namespace ZZG.Entities
{
    public class ProductCategory
    {
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }
        public int ProductId { get; set; }
        public List<Product> products { get; set; }
    }
}
