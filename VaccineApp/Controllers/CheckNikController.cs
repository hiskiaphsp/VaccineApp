using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VaccineApp.Models;

namespace VaccineApp.Controllers
{
    public class CheckNikController : Controller
    {
        // GET: CheckNik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SearchNik(string searchQuery)
        {
            // Create an instance of your WCF service client
            MyServiceReference.Service1Client client = new MyServiceReference.Service1Client();

            // Call the method in your WCF service to get the arrays of communities, vaccines, hospitals, and vaccine records
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
                        where c.nik.Equals(searchQuery) // Filter based on NIK
                        select new CommunityVaccineRecord
                        {
                            Id = c.id,
                            CommunityName = c.name,
                            NIK = c.nik,
                            VaccineName = v.vaccine_name,
                            VaccineDate = vr.vaccine_date ?? DateTime.MinValue,
                            AdministrationType = vr.administration_type,
                            NurseName = vr.nurse_name,
                            HospitalName = h.hospital_name
                        };

            // Pass the joined result to the partial view
            if (query.Any())
            {
                // Pass the joined result to the partial view

                return PartialView("~/Views/CheckNik/_SearchNik.cshtml", query.ToList());
            }
            else
            {
                TempData["error"] = "NIK not found!";

                // No matching records found, return an empty partial view
                return PartialView("~/Views/CheckNik/_EmptySearch.cshtml");
            }
        }

    }
}