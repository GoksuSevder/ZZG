using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZZG.Business.Abstract;
using ZZG.WebUI.Models;

namespace ZZG.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        //private ICategoryService _categoryService;

        public HomeController(IProductService productService
            //,ICategoryService categoryService
            )
        {
            _productService = productService;
            //_categoryService = categoryService;
        }
        public IActionResult Index()
        {

            return View(new ProducyListModel()
            {
                Products = _productService.GetAll()

            });
        }
    }
}
