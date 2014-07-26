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

       // public ActionResult AddLocation()
       // {
            
       //     return View();
       // }

       // [HttpPost]
       // public ActionResult AddLocation(FormCollection form)
       // {
       //     var entity = new MyBestDBEntities();

       //     var location = new Location{ Name = form["Name"] };
       //     entity.Locations.Add(location);
       //     entity.SaveChanges();
       //     return View();
       // }

       // public ActionResult AddProducer()
       // {
       //     return View();
       // }

       //[HttpPost]
       // public ActionResult AddProducer(FormCollection form)
       // {
       //     var entity = new MyBestDBEntities();

       //     var producer = new Producer { Name = form["Name"], LocationId = Convert.ToInt32(form["LocationId"])};
       //     entity.Producers.Add(producer);
       //     entity.SaveChanges();
       //     return View();
       // }

       // public ActionResult AddProduct()
       // {
       //     return View();
       // }

       // [HttpPost]
       // public ActionResult AddProduct(FormCollection form)
       // {
       //     var entity = new MyBestDBEntities();
       //     var product = new Product { Name = form["Name"], Price = Convert.ToDecimal(form["Price"]), Count = Convert.ToInt32(form["Count"])};
       //     entity.Products.Add(product);
       //     entity.SaveChanges();
       //     return View();
       // }

        

        public ActionResult AddLocation()
        {
            return View(new Location ());
        }

        [HttpPost]
        public ActionResult SaveLocation(Location model)
        {
            var entity = new MyBestDBEntities();
            entity.Locations.Add(model);
            entity.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddProducer()
        {
            var entity = new MyBestDBEntities();
            var locations = entity.Locations.ToList();

            var locationList = locations.Select(x => { return new SelectListItem { Text = x.Name, Value = x.Id.ToString() }; }).ToList();

            ViewBag.Locations = locationList;
            return View(new Producer());
        }

        public ActionResult SaveProducer(Producer model)
        {
            var entity = new MyBestDBEntities();
            var location = entity.Locations.ToList().First(x => x.Id == model.LocationId);
            model.Location = location;
            entity.Producers.Add(model);
            entity.SaveChanges();
            return RedirectToAction("Index");
        }

       public ActionResult AddProduct()
        {
            var entity = new MyBestDBEntities();
            var producers = entity.Producers.ToList();
            var producerList = producers.Select(x => { return new SelectListItem { Text = x.Name, Value = x.Id.ToString() }; }).ToList();

            ViewBag.Producers = producerList;
           
            return View(new Product());
        }

         [HttpPost]
       public ActionResult SaveProduct(Product model)
       {
           var entity = new MyBestDBEntities();
           var producer = entity.Producers.ToList().First(x => x.Id == model.ProducerID);
           model.Producer = producer;

           entity.Products.Add(model);
           entity.SaveChanges();

           return RedirectToAction("Index");
       }

    }
}
