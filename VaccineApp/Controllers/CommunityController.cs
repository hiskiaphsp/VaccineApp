using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineApp.Models;
using System.Web.Mvc;
using VaccineApp.MyServiceReference;


namespace VaccineApp.Controllers
{
    public class CommunityController : Controller
    {
        private MyServiceReference.Service1Client client;

        public CommunityController()
        {
            client = new MyServiceReference.Service1Client();
        }
        // GET: Community
        public ActionResult Index()
        {
            // Create an instance of your WCF service client
            MyServiceReference.Service1Client client = new MyServiceReference.Service1Client();

            // Call the method in your WCF service to get the array of communities
            MyServiceReference.community[] communitiesArray = client.GetCommunities();

            // Convert the array of communities to a list of Community objects
            List<community> communities = communitiesArray.Select(c => new community
            {
                id = c.id,
                nik = c.nik,
                name = c.name,
                date_of_birth = c.date_of_birth,
                address = c.address,
                city = c.city,
                province = c.province,
                country = c.country,
                phone_number = c.phone_number,
                email = c.email
            }).ToList();

            // Pass the list of communities to the view
            return View(communities);
        }
        [HttpGet]
        public ActionResult CreateCommunity()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCommunity(community model)
        {
            if (ModelState.IsValid)
            {
                client.AddCommunity(model);
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
        public ActionResult EditCommunity(int id)
        {
            var community = client.GetCommunityById(id);
            if (community == null)
            {
                TempData["error"] = "Community not found.";
                return RedirectToAction("Index");
            }

            return View(community);
        }

        [HttpPost]
        public ActionResult UpdateCommunity(community model)
        {
            if (ModelState.IsValid)
            {
                client.UpdateCommunity(model);
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
        public ActionResult DeleteCommunity(int id)
        {
            client.DeleteCommunity(id);
            TempData["success"] = "Data berhasil dihapus!";
            return RedirectToAction("Index");
        }
    }
}