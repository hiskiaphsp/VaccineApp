using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VaccineApp.Models;
using VaccineApp.MyServiceReference;

namespace VaccineApp.Controllers
{
    public class VaccineRecordController : Controller
    {
        private MyServiceReference.Service1Client client;

        public VaccineRecordController()
        {
            client = new MyServiceReference.Service1Client();
        }
        public ActionResult Index()
        {
            // Create an instance of your WCF service client
            MyServiceReference.Service1Client client = new MyServiceReference.Service1Client();

            // Call the method in your WCF service to get the array of communities
            MyServiceReference.community[] communitiesArray = client.GetCommunities();
            MyServiceReference.vaccine[] vaccinesArray = client.GetVaccines();
            MyServiceReference.hospital[] hospitalsArray = client.GetHospitals();
            MyServiceReference.vaccine_records[] vaccineRecordsArray = client.GetVaccineRecords();

            // Convert the arrays to lists
            List<MyServiceReference.community> communities = communitiesArray.ToList();
            List<MyServiceReference.vaccine> vaccines = vaccinesArray.ToList();
            List<MyServiceReference.hospital> hospitals = hospitalsArray.ToList();
            List<MyServiceReference.vaccine_records> vaccineRecords = vaccineRecordsArray.ToList();

            // Perform the join between communities, vaccine_records, vaccines, and hospitals
            var query = from vr in vaccineRecords
                        join c in communities on vr.community_id equals c.id
                        join v in vaccines on vr.vaccine_id equals v.id
                        join h in hospitals on vr.hospital_id equals h.id
                        select new CommunityVaccineRecord
                        {
                            Id = c.id,
                            CommunityName = c.name,
                            VaccineName = v.vaccine_name,
                            VaccineDate = vr.vaccine_date ?? DateTime.MinValue,
                            AdministrationType = vr.administration_type,
                            NurseName = vr.nurse_name,
                            HospitalName = h.hospital_name
                        };

            // Pass the joined result to the view
            return View(query.ToList());
        }
        [HttpGet]
        public ActionResult AddVaccineRecord()
        {
            var communities = client.GetCommunities();
            var vaccines = client.GetVaccines();
            var hospitals = client.GetHospitals();

            var model = new vaccine_records();

            // Mengisi data produsen dan vaksin ke dalam ViewData atau ViewBag
            ViewBag.Communities = new SelectList(communities, "id", "nik");
            ViewBag.Vaccines = new SelectList(vaccines, "id", "vaccine_name");
            ViewBag.Hospitals = new SelectList(hospitals, "id", "hospital_name");
            return View(model);
        }

        [HttpPost]
        public ActionResult AddVaccineRecord(vaccine_records model)
        {
            if (ModelState.IsValid)
            {
                client.AddVaccineRecord(model);
                TempData["success"] = "Data berhasil ditambahkan!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Invalid vaccine Record data.";
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult EditVaccineRecord(int id)
        {
            // Get the list of vaccines
            var vaccines = client.GetVaccines();
            var communities = client.GetCommunities();
            var hospitals = client.GetHospitals();


            // Get the vaccine Record data
            var vaccineRecord = client.GetVaccineRecordById(id); // Replace this with your code to fetch the vaccine Record by ID

            // Set the ViewBag or ViewData for vaccines
            ViewBag.Vaccines = new SelectList(vaccines, "id", "vaccine_name", vaccineRecord.vaccine_id);
            ViewBag.Communities = new SelectList(communities, "id", "name", vaccineRecord.community_id);
            ViewBag.Hospitals = new SelectList(hospitals, "id", "hospital_name", vaccineRecord.hospital_id);

            if (vaccineRecord == null)
            {
                TempData["error"] = "Vaccine Record not found.";
                return RedirectToAction("Index");
            }

            return View(vaccineRecord);
        }


        [HttpPost]
        public ActionResult UpdateVaccineRecord(vaccine_records model)
        {
            if (ModelState.IsValid)
            {
                client.UpdateVaccineRecord(model);
                TempData["success"] = "Data berhasil diperbarui!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Invalid vaccine Record data.";
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteVaccineRecord(int id)
        {
            client.DeleteVaccineRecord(id);
            TempData["success"] = "Data berhasil dihapus!";
            return RedirectToAction("Index");
        }
    }
}