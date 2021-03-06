using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZZG.Entities;

namespace ZZG.WebUI.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
