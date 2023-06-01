using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VaccineApp.Models;
using VaccineApp.MyServiceReference;


namespace VaccineApp.Controllers
{
    public class VaccineProducerController : Controller
    {
        private MyServiceReference.Service1Client client;

        public VaccineProducerController()
        {
            client = new MyServiceReference.Service1Client();
        }
        // GET: VaccineProducer
        public ActionResult Index()
        {
            // Create an instance of your WCF service client
            MyServiceReference.Service1Client client = new MyServiceReference.Service1Client();

            // Call the method in your WCF service to get the array of producers
            MyServiceReference.producer[] producersArray = client.GetProducers();
            MyServiceReference.vaccine_producers[] vaccineProducersArray = client.GetVaccineProducers();
            MyServiceReference.vaccine[] vaccinesArray = client.GetVaccines();

            // Convert the array of producers to a list of Producer objects
            List<MyServiceReference.producer> producers = producersArray.ToList();
            List<MyServiceReference.vaccine_producers> vaccineProducers = vaccineProducersArray.ToList();
            List<MyServiceReference.vaccine> vaccines = vaccinesArray.ToList();


            // Perform the join between producers, vaccine_producers, and vaccines
            var query = from vp in vaccineProducers
                        join p in producers on vp.producer_id equals p.id
                        join v in vaccines on vp.vaccine_id equals v.id
                        select new ProducerVaccine
                        {
                            Id = p.id,
                            ProducerName = p.producer_name,
                            VaccineName = v.vaccine_name,
                            Address = p.address,
                            City = p.city,
                            Province = p.province,
                            Country = p.country,
                            PhoneNumber = p.phone_number,
                            VaccineType = v.vaccine_type,
                            Dose = v.dose,
                        };

            // Pass the joined result to the view
            return View(query.ToList());
        }

        [HttpGet]
        public ActionResult AddVaccineProducer()
        {
            var producers = client.GetProducers();

            // Mendapatkan data vaksin dari sumber data yang sesuai
            var vaccines = client.GetVaccines();

            var model = new vaccine_producers();

            // Mengisi data produsen dan vaksin ke dalam ViewData atau ViewBag
            ViewBag.Producers = new SelectList(producers, "id", "producer_name");
            ViewBag.Vaccines = new SelectList(vaccines, "id", "vaccine_name");
            return View(model);
        }

        [HttpPost]
        public ActionResult AddVaccineProducer(vaccine_producers model)
        {
            if (ModelState.IsValid)
            {
                client.AddVaccineProducer(model);
                TempData["success"] = "Data berhasil ditambahkan!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Invalid vaccine producer data.";
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult EditVaccineProducer(int id)
        {
            // Get the list of vaccines
            var vaccines = client.GetVaccines();
            var producers = client.GetProducers();

            // Get the vaccine producer data
            var vaccineProducer = client.GetVaccineProducerById(id); // Replace this with your code to fetch the vaccine producer by ID

            // Set the ViewBag or ViewData for vaccines
            ViewBag.Vaccines = new SelectList(vaccines, "id", "vaccine_name", vaccineProducer.vaccine_id);
            ViewBag.Producers = new SelectList(producers, "id", "producer_name", vaccineProducer.producer_id);

            if (vaccineProducer == null)
            {
                TempData["error"] = "Vaccine producer not found.";
                return RedirectToAction("Index");
            }

            return View(vaccineProducer);
        }


        [HttpPost]
        public ActionResult UpdateVaccineProducer(vaccine_producers model)
        {
            if (ModelState.IsValid)
            {
                client.UpdateVaccineProducer(model);
                TempData["success"] = "Data berhasil diperbarui!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Invalid vaccine producer data.";
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteVaccineProducer(int id)
        {
            client.DeleteVaccineProducer(id);
            TempData["success"] = "Data berhasil dihapus!";
            return RedirectToAction("Index");
        }

    }
}