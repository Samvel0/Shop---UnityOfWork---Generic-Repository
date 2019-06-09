using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.DbTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.CategoryManagement;
using TestWeb.Models;

namespace TestWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryservice;
        public CategoryController(ICategoryService categoryservice)
        {
            _categoryservice = categoryservice;
        }
        // GET: Category
        public ActionResult Index()
        {
            var result = _categoryservice.GetAllCategories().ToList();
            var list = new List<CategoryModel>();
            foreach (var categoty in result)
            {
                list.Add(new CategoryModel { Id = categoty.Id, Name = categoty.Name });
            }
            return View(list);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                _categoryservice.AddCategory(new Category { Name = collection["Name"] })
;                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _categoryservice.GetCategoryById(id);
            var category = new CategoryModel { Id = result.Id, Name = result.Name };
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                _categoryservice.EditCategory(new Category { Id = id, Name = collection["Name"] });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var result = _categoryservice.GetCategoryById(id);
            var category = new CategoryModel { Id = result.Id, Name = result.Name };
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _categoryservice.DeleteCategory(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}