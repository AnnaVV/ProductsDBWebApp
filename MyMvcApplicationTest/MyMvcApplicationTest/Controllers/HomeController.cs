using MyMvcApplicationTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvcApplicationTest.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            //var entity = new MyBestDBEntities();
            //entity.Locations.Add(new Location { Name = "Kyiv" });

            //var locations = entity.Locations.ToList().First(x => x.Id == 1);

            ////entity.Producers.Add(new Producer
            ////{
            ////    Location = locations,
            ////    Name = "Saturn"
            ////});

            //var prod = entity.Producers.ToList().First(x => x.Id == 1);

            //entity.Products.Add(new Product
            //{
            //    Producer = prod,
            //    Name = "TV",
            //    Count = 1,
            //    Price = 10.1m

            //});
     
            //entity.SaveChanges();
            return View();
        }

        public ActionResult AddLocation()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult AddLocation(FormCollection form)
        {
            var entity = new MyBestDBEntities();

            var location = new Location{ Name = form["Name"] };
            entity.Locations.Add(location);
            entity.SaveChanges();
            return View();
        }

        public ActionResult AddProducer()
        {
            return View();
        }

       [HttpPost]
        public ActionResult AddProducer(FormCollection form)
        {
            var entity = new MyBestDBEntities();

            var producer = new Producer { Name = form["Name"], LocationId = Convert.ToInt32(form["LocationId"])};
            entity.Producers.Add(producer);
            entity.SaveChanges();
            return View();
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(FormCollection form)
        {
            var entity = new MyBestDBEntities();
            var product = new Product { Name = form["Name"], Price = Convert.ToDecimal(form["Price"]), Count = Convert.ToInt32(form["Count"])};
            entity.Products.Add(product);
            entity.SaveChanges();
            return View();
        }

    }
}
