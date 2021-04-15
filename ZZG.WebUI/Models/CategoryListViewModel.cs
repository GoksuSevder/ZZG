using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZZG.Entities;

namespace ZZG.WebUI.Models
{
    public class CategoryListViewModel
    {
        public string SelectedCategory { get; set; }
        public List<Category> Categories { get; set; }
    }
}
