using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VaccineApp.Controllers
{
    public class CheckVaccineController : Controller
    {
        // GET: CheckVaccine
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
    }
}