using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZZG.Business.Abstract;
using ZZG.Entities;
using ZZG.WebUI.Models;

namespace ZZG.WebUI.Controllers
{
    public class AdminController : Controller
    {
        IProductService _productService;
        ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult ProductList()
        {
            return View(new ProductListModel()
            {

                Products = _productService.GetAll()
            });
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            ProductModel model = new ProductModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductModel model)
        {
            if (ModelState.IsValid==true)
            {
                var entity = new Product
                {
                    Name = model.Name,
                    ImageUrl = model.ImageUrl,
                    Description = model.Description,
                    Price = model.Price
                };
                _productService.Create(entity);
                return RedirectToAction("ProductList");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _productService.GetProductWithCategories((int)id);

            if (entity == null)
            {
                return NotFound();
            }
            ProductModel model = new ProductModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                Price=entity.Price,
                SelectedCategories=entity.ProductCategories.Select(p => p.Category).ToList()
            };
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }
        [HttpPost]
        public IActionResult EditProduct(ProductModel model, int[] categoryIds)
        {
            if (ModelState.IsValid==true)
            {
                var entity = new Product
                {
                    Id = model.Id,
                    Name = model.Name,
                    ImageUrl = model.ImageUrl,
                    Description = model.Description,
                    Price = model.Price
                };
                _productService.Update(entity, categoryIds);
                return RedirectToAction("ProductList");
            }
             ViewBag.Categories = _categoryService.GetAll();
            return RedirectToAction("EditProduct");
        }
        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            var entity = _productService.GetById(productId);
            if (entity != null)
            {
                _productService.Delete(entity);
            }
            return RedirectToAction("ProductList");
        }

        public IActionResult CategoryList()
        {
            return View(new CategoryListModel()
            {
                Categories = _categoryService.GetAll()
            });
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            CategoryModel model = new CategoryModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryModel model)
        {
            if (ModelState.IsValid==true)
            {
                var entity = new Category()
                {
                    Name = model.Name
                };
                _categoryService.Create(entity);
                return RedirectToAction("CategoryList");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category category = _categoryService.GetByIdWithProducts((int)id);
            if (category == null)
            {
                return NotFound();
            }
            var model = new CategoryModel
            {
                Id = category.Id,
                Name = category.Name,
                Products = category.ProductCategories.Select(p => p.Product).ToList()

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult EditCategory(CategoryModel model, int id)
        {
            if (ModelState.IsValid==true)
            {
                var entity = new Category
                {
                    Id = id,
                    Name = model.Name
                };
                _categoryService.Update(entity);
                return RedirectToAction("CategoryList");
            }
            return RedirectToAction("EditCategory");
        }
        [HttpPost]
        public IActionResult DeleteCategory(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);
            if (entity != null)
            {
                _categoryService.Delete(entity);
            }
            return RedirectToAction("CategoryList");
        }
        [HttpPost]
        public IActionResult DeleteFromCategory(int categoryId, int productId)
        {
            _categoryService.DeleteFromCategory(categoryId, productId);


            return Redirect("/admin/editcategory/" + categoryId);
        }

    }
}
