using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZZG.Business.Abstract;
using ZZG.WebUI.Models;

namespace ZZG.WebUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            return View(new CategoryListViewModel()
            {
                SelectedCategory =RouteData.Values["category"]?.ToString(),
                Categories = _categoryService.GetAll()
            }); ;
        }
    }
}
