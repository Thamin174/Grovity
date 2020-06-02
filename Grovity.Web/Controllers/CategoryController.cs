﻿using Grovity.Entities;
using Grovity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grovity.Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoriesService categoryService = new CategoriesService();
        // GET: Category
        public ActionResult Index()
        {
            var categories = categoryService.GetCategories();

            return View(categories);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoryService.SaveCategory(category);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int ID)
        {
            var category = categoryService.GetCategory(ID);

            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            categoryService.UpdateCategory(category);

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int ID)
        {
            var category = categoryService.GetCategory(ID);

            return View(category);
        }
        [HttpPost]
        public ActionResult Delete(Category category)
        {

            categoryService.DeleteCategory(category.ID);

            return RedirectToAction("Index");
        }
    }
}