using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.DbTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceContracts.ProductManagement;
using TestWeb.Models;

namespace TestWeb.Controllers
{
    //[Route("Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: Product
        public ActionResult Index()
        {
            var result = _productService.GetAllProducts().ToList();
            var list = new List<ProductModel>();
            foreach (var product in result)
            {
                list.Add(new ProductModel { Id = product.Id, Name = product.Name, Price = product.Price, CategoryId = product.CategoryId});
            }
            return View(list);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            IEnumerable<Category> categories = _productService.GetCategoryList();

            ViewBag.CategoryList = new SelectList(categories, "Id", "Name");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var product = new Product
                {
                    CategoryId = Convert.ToInt32(collection["CategoryId"]),
                    Name = collection["Name"],
                    Price = float.Parse(collection["Price"])
                };
                _productService.AddProduct(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _productService.GetProductId(id);
            var product = new ProductModel { Id = result.Id, Name = result.Name, Price = result.Price, CategoryId = result.CategoryId};

            IEnumerable<Category> categories = _productService.GetCategoryList();
            ViewBag.CategoryList = new SelectList(categories, "Id", "Name");
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var product = new Product
                {
                    Id = id,
                    CategoryId = Convert.ToInt32(collection["CategoryId"]),
                    Name = collection["Name"],
                    Price = float.Parse(collection["Price"])
                };
                _productService.EditProduct(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var result = _productService.GetProductId(id);
            var product = new ProductModel { Id = result.Id, Name = result.Name, Price = result.Price };
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _productService.DeleteProduct(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}