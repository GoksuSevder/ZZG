using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ZZG.Entities;

namespace ZZG.WebUI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="İsim alanı boş bırakılamaz.")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Ürün ismi minumum 5, maksimum 60 karakter olmalıdır.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Fotoğraf alanı boş bırakılamaz.")]
        [StringLength(20,ErrorMessage = "Resim yüklemeniz gereklidir.")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Açıklama alanı boş bırakılamaz.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Ürün açıklaması minumum 10, maksimum 100 karakter olmalıdır.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Fiyat alanı boş bırakılamaz.")]
        [Range(1,10000)]
        public decimal? Price { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
}
