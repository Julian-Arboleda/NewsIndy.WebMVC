using Microsoft.AspNet.Identity;
using NewsIndy.Data;
using NewsIndy.Models;
using NewsIndy.Services;
using NewsIndy.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsIndy.WebMVC.Controllers
{
    [Authorize]
    public class BoroughController : Controller
    {
        private BoroughService CreateBoroughService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BoroughService(userId);
            return service;
        }

        // GET: Borough
        [AllowAnonymous]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BoroughService(userId);
            var model = service.GetBoroughs();

            return View(model);
        }

        [AllowAnonymous]
        public IEnumerable<BoroughListItem> GetBoroughList()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Boroughs.Select(o => new BoroughListItem
                {
                    BoroughId = o.BoroughId,
                    Name = o.Name,
                    Direction = o.Direction
                });

                return query.ToArray();
            }
        }

      

        // GET
        public ActionResult Create()
        {
            ViewBag.Title = "Boroughs";
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

            var service = CreateBoroughService();

            if (service.CreateBorough(model))
            {
                TempData["SaveResult"] = "Your borough was created. ";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Borough could not be created.");

            return View(model);
        }

        // GET: Details
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var svc = CreateBoroughService();
            var model = svc.GetBoroughById(id);

            return View(model);
        }

        // GET: 
        public ActionResult Edit(int id)
        {
            var service = CreateBoroughService();
            var detail = service.GetBoroughById(id);
            var model =
                new BoroughEdit
                {
                    BoroughId = detail.BoroughId,
                    Name = detail.Name,
                    Direction = detail.Direction
                };
            return View(model);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BoroughEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.BoroughId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateBoroughService();

            if (service.UpdateBorough(model))
            {
                TempData["SaveResult"] = "Your borough was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your borough could not be updated.");
            return View(model);

        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateBoroughService();
            var model = svc.GetBoroughById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBorough(int id)
        {
            var service = CreateBoroughService();
            service.DeleteBorough(id);
            TempData["SaveResult"] = "Your borough was deleted";
            return RedirectToAction("Index");
        }
    }
}