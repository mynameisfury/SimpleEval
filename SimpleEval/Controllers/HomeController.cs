using Newtonsoft.Json.Linq;
using SimpleEval.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleEval.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db = new ApplicationContext();
        public ActionResult Index()
        {
            return View(db.Products.ToList());
           
        }

        [HttpPost]
        public ActionResult SaveProduct(int id, string propertyName, string value)
        {
            var status = false;
            var message = "";

            var product = db.Products.Find(id);
            if (product != null)
            {
                db.Entry(product).Property(propertyName).CurrentValue = value;
                db.SaveChanges();
                status = true;
            }
            else
            {
                message = "error";
            }



            var response = new { value = value, status = status, message = message };
            JObject o = JObject.FromObject(response);
            return Content(o.ToString());
        }

        [HttpPost]
        public ActionResult Create(Product input)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    ProductName = input.ProductName,
                    ProductDescription = input.ProductDescription,
                    DateAdded = DateTime.Now,
                    InStockQuantity = input.InStockQuantity
                };
                db.Products.Add(product);
                db.SaveChanges();
                string message = "Success";
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            return View();
        }





        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}