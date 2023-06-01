using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VaccineApp.MyServiceReference;


namespace VaccineApp.Controllers
{
    public class HospitalController : Controller
    {
        private MyServiceReference.Service1Client client;

        public HospitalController()
        {
            client = new MyServiceReference.Service1Client();
        }
        // GET: Hospital
        public ActionResult Index()
        {
            // Create an instance of your WCF service client
            MyServiceReference.Service1Client client = new MyServiceReference.Service1Client();

            // Call the method in your WCF service to get the array of vaccines
            MyServiceReference.hospital[] hospitalArray = client.GetHospitals();

            // Convert the array to a list
            List<MyServiceReference.hospital> hospitals = hospitalArray.ToList();

            // Pass the list of vaccines to the view
            return View(hospitals);
        }

        public ActionResult AddHospital()
        {
            // Tampilkan view untuk menambahkan rumah sakit
            return View();
        }

        [HttpPost]
        public ActionResult AddHospital(hospital model)
        {
            if (ModelState.IsValid)
            {
                client.AddHospital(model);
                TempData["success"] = "Data berhasil ditambahkan!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Invalid community data.";
                return View(model);
            }
        }

        public ActionResult EditHospital(int id)
        {
            // Dapatkan data rumah sakit berdasarkan ID dari service atau repository yang sesuai
            var model = client.GetHospitalById(id);

            if (model == null)
            {
                // Jika data rumah sakit tidak ditemukan, tampilkan halaman atau pesan error yang sesuai
                return HttpNotFound();
            }

            // Tampilkan view untuk mengedit rumah sakit dengan data yang telah ditemukan
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateHospital(hospital model)
        {
            if (ModelState.IsValid)
            {
                client.UpdateHospital(model);
                TempData["success"] = "Data berhasil diperbarui!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Invalid community data.";
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteHospital(int id)
        {
            client.DeleteHospital(id);
            TempData["success"] = "Data berhasil dihapus!";
            return RedirectToAction("Index");
        }
    }
}