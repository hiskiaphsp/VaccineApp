using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VaccineApp.MyServiceReference; // Ganti dengan namespace referensi layanan WCF yang sesuai

namespace VaccineApp.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // Create an instance of your WCF service client
            MyServiceReference.Service1Client client = new MyServiceReference.Service1Client();

            // Call the Login method in your WCF service
            MyServiceReference.user user = client.Login(username, password);

            if (user != null)
            {
                // Login successful, store user data in session
                Session["UserId"] = user.id;
                Session["Username"] = user.username;
                Session["Role"] = user.roles;

                // Redirect the user to the home page
                TempData["successLogin"] = "Selamat datang, " + user.username + "!";

                return RedirectToAction("Index", "App");
            }
            else
            {
                // Login failed, display error message
                TempData["error"] = "Username or password is incorrect.";
                return View();
            }
        }
        public ActionResult Logout()
        {
            // Clear session data
            Session.Clear();
            Session.Abandon();

            // Redirect the user to the login page
            return RedirectToAction("Index", "Home");
        }



    }
}
