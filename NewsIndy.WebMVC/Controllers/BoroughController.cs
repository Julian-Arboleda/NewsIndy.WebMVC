using Microsoft.AspNet.Identity;
using NewsIndy.Data;
using NewsIndy.Models;
using NewsIndy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsIndy.WebMVC.Controllers
{
    public class BoroughController : Controller
    {
        // GET: Borough
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BoroughService(userId);
            var model = service.GetBoroughs();

            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        // POST: Borough
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BoroughCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BoroughService(userId);
            service.CreateBorough(model);

            return RedirectToAction("Index");
        }
    }
}