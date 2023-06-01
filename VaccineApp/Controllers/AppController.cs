using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineApp.Models;
using System.Web.Mvc;
using VaccineApp.MyServiceReference;

namespace VaccineApp.Controllers
{
    public class AppController : Controller
    {
        // GET: App
/*        public ActionResult Index()
        {
            return View();
        }*/
        public ActionResult AddVaccine()
        {
            return View();
        }
        public ActionResult Index()
        {
            // Create an instance of your WCF service client
            MyServiceReference.Service1Client client = new MyServiceReference.Service1Client();

            // Call the method in your WCF service to get the array of vaccines
            MyServiceReference.vaccine[] vaccinesArray = client.GetVaccines();

            // Convert the array to a list
            List<MyServiceReference.vaccine> vaccines = vaccinesArray.ToList();

            // Pass the list of vaccines to the view
            return View(vaccines);
        }


        [HttpPost]
        public ActionResult AddVaccine(vaccine model)
        {
            if (string.IsNullOrWhiteSpace(model.vaccine_name) ||
                string.IsNullOrWhiteSpace(model.vaccine_type) ||
                model.dose_count == null ||
                string.IsNullOrWhiteSpace(model.dose) ||
                model.price == null)
            {
                TempData["error"] = "All fields are required.";
                return View(model);
            }

            // Create an instance of your WCF service client
            MyServiceReference.Service1Client client = new MyServiceReference.Service1Client();

            // Call the AddVaccine method in your WCF service by passing the Vaccine model
            client.AddVaccine(model);

            // Redirect to the appropriate page after successful saving
            TempData["success"] = "Data berhasil ditambahkan!";

            return RedirectToAction("Index", "App");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            // Create an instance of your WCF service client
            MyServiceReference.Service1Client client = new MyServiceReference.Service1Client();

            // Retrieve the vaccine data from your WCF service based on the provided ID
            vaccine model = client.GetVaccineById(id);

            if (model == null)
            {
                // Vaccine not found, redirect to an appropriate error page or handle accordingly
                return RedirectToAction("Error", "App");
            }

            // Pass the vaccine model to the view for editing
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateVaccine(vaccine model)
        {
            if (string.IsNullOrWhiteSpace(model.vaccine_name) ||
                string.IsNullOrWhiteSpace(model.vaccine_type) ||
                model.dose_count == null ||
                string.IsNullOrWhiteSpace(model.dose) ||
                model.price == null)
            {
                TempData["error"] = "All fields are required.";
                return View(model);
            }

            // Create an instance of your WCF service client
            MyServiceReference.Service1Client client = new MyServiceReference.Service1Client();

            // Call the UpdateVaccine method in your WCF service by passing the Vaccine model
            client.UpdateVaccine(model);

            // Redirect to the appropriate page after successful update
            TempData["success"] = "Data berhasil diperbarui!";

            return RedirectToAction("Index", "App");
        }

        public ActionResult DeleteVaccine(int id)
        {
            try
            {
                // Create an instance of your WCF service client
                MyServiceReference.Service1Client client = new MyServiceReference.Service1Client();

                // Call the DeleteVaccine method in your WCF service
                client.DeleteVaccine(id);

                // Close the WCF service client
                client.Close();

                TempData["success"] = "Vaccine deleted successfully.";
            }
            catch (Exception ex)
            {
                TempData["error"] = "An error occurred while deleting the vaccine: " + ex.Message;
            }

            // Redirect the user to the index page
            return RedirectToAction("Index");
        }

    }
}