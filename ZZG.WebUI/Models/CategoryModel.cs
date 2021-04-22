using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ZZG.Entities;

namespace ZZG.WebUI.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="İsim alanı boş bırakılamaz")]
        [StringLength(100, MinimumLength  = 3, ErrorMessage = "Kategori ismi minumum 3, maksimum 100 karakter olmalıdır.")]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
