using Microsoft.AspNet.Identity;
using NewsIndy.Models;
using NewsIndy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsIndy.WebMVC.Controllers
{
    public class OrganizationController : Controller
    {
        
        // GET: Organization
        public ActionResult Index()
        {
            return View(new OrganizationService().GetOrganizationList());
        }

        // GET
        public ActionResult Create()
        {
            ViewBag.Title = "Organizations";
            return View();
        }

        // POST: Org
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrganizationCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new OrganizationService();

            if (service.CreateOrganization(model))
            {
                TempData["SaveResult"] = "Your organization was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Organization could not be created");

            return View(model);
        }

        // GET:
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var service = new OrganizationService();
            var detail = service.GetOrganizationById(id);
            var model =
                new OrganizationEdit
                {
                    OrgId = detail.OrgId,
                    Name = detail.Name,
                    IsFoodBank = detail.IsFoodBank,
                    IsShelter = detail.IsShelter,
                    BoroughId = detail.BoroughId
                };
            return View(model);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrganizationEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.OrgId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new OrganizationService();

            if (service.UpdateOrganization(model))
            {
                TempData["SaveResult"] = "Your organization was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your organization could not be updated.");
            return View(model);
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = new OrganizationService();
            var model = svc.GetOrganizationById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOrganization(int id)
        {
            var service = new OrganizationService();
            service.DeleteOrganization(id);
            TempData["SaveResult"] = "Your organization was deleted";
            return RedirectToAction("Index");
        }
    }
}