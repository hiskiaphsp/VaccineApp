using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VaccineApp.MyServiceReference;


namespace VaccineApp.Controllers
{
    public class UserController : Controller
    {
        private MyServiceReference.Service1Client client;

        public UserController()
        {
            client = new MyServiceReference.Service1Client();
        }

        // GET: User
        public ActionResult Index()
        {
            // Create an instance of your WCF service client
            MyServiceReference.Service1Client client = new MyServiceReference.Service1Client();

            // Call the method in your WCF service to get the array of vaccines
            MyServiceReference.user[] userArray = client.GetUsers();

            // Convert the array to a list
            List<MyServiceReference.user> users = userArray.ToList();

            // Pass the list of vaccines to the view
            return View(users);
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(user model)
        {
            if (ModelState.IsValid)
            {
                client.AddUser(model);
                TempData["success"] = "Data berhasil ditambahkan!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Invalid community data.";
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var user = client.GetUserById(id);
            if (user == null)
            {
                TempData["error"] = "User not found.";
                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult UpdateUser(user model)
        {
            if (ModelState.IsValid)
            {
                client.UpdateUser(model);
                TempData["success"] = "User data updated successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Invalid user data.";
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            client.DeleteUser(id);
            TempData["success"] = "User data deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}