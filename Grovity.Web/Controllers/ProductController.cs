using Grovity.Entities;
using Grovity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grovity.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductsService productsService = new ProductsService();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTable()
        {
            var products = productsService.GetProducts();

            return PartialView(products);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            productsService.SaveProduct(product);

            return RedirectToAction("ProductTable");
        }

        public ActionResult Edit(int ID)
        {
            var product = productsService.GetProduct(ID);

            return View();
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {

            productsService.UpdateProduct(product);

            return RedirectToAction("ProductTable");
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {

            productsService.DeleteProduct(ID);

            return RedirectToAction("ProductTable");
        }
    }
}