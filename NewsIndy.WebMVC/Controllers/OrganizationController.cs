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
    [Authorize]
    public class OrganizationController : Controller
    {
        // GET: Organization
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(new OrganizationService().GetOrganizationList());
        }

        // GET
        public ActionResult Create()
        {
            ViewBag.Title = "Organizations";

            List<BoroughListItem> Boroughs = (new BoroughService()).GetBoroughs().ToList();
            //Borough.Select(o => new SelectListItem() { }); may be async error, prefer this way -->
            var query = from b in Boroughs
                        select new SelectListItem()
                        {
                            Value = b.BoroughId.ToString(),
                            Text = b.Name
                        };
            ViewBag.BoroughId = query.ToList();

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
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var svc = new OrganizationService();
            var model = svc.GetOrganizationById(id);

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
                    Description = detail.Description,
                    BoroughId = detail.BoroughId
                };

            List<BoroughListItem> Boroughs = (new BoroughService()).GetBoroughs().ToList();
            /* ViewBag.BoroughId = Boroughs.Select(b => new SelectListItem() 
              {
                  Value = b.BoroughId.ToString(),
                  Text = b.Name,
                  Selected = service.BoroughId == b.BoroughId
              }); */

            var query = from b in Boroughs
                        select new SelectListItem()
                        {
                            Value = b.BoroughId.ToString(),
                            Text = b.Name
                        };
            ViewBag.BoroughId = query.ToList();
            return View(model);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrganizationEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.OrgId != id)
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