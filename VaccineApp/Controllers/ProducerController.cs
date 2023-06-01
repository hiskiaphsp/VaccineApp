using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using VaccineApp.MyServiceReference;


namespace VaccineApp.Controllers
{
    public class ProducerController : Controller
    {
        // GET: Producer
        public ActionResult Index()
        {
            // Create an instance of your WCF service client
            MyServiceReference.Service1Client client = new MyServiceReference.Service1Client();

            // Call the method in your WCF service to get the array of producers
            MyServiceReference.producer[] producersArray = client.GetProducers();

            // Convert the array of producers to a list of Producer objects
            List<MyServiceReference.producer> producers = producersArray.ToList();


            // Pass the list of producers to the view
            return View(producers);
        }

        public ActionResult AddProducer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProducer(producer model)
        {
            using (var service = new MyServiceReference.Service1Client())
            {
                service.AddProducer(model);
            }
            TempData["success"] = "Data berhasil ditambahkan!";

            return RedirectToAction("Index", "Producer");
        }

        public ActionResult EditProducer(int id)
        {
            using (var service = new MyServiceReference.Service1Client())
            {
                var producer = service.GetProducerById(id);
                if (producer != null)
                {
                    return View(producer);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateProducer(producer model)
        {
            using (var service = new MyServiceReference.Service1Client())
            {
                service.UpdateProducer(model);
            }
            TempData["success"] = "Data berhasil diperbaharui!";

            return RedirectToAction("Index", "Producer");
        }

        [HttpGet]
        public ActionResult DeleteProducer(int id)
        {
            using (var service = new MyServiceReference.Service1Client())
            {
                service.DeleteProducer(id);
            }
            TempData["success"] = "Data berhasil dihapus!";
            return RedirectToAction("Index");
        }
    }
}