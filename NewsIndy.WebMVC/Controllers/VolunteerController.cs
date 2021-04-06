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
    public class VolunteerController : Controller
    {

        // GET: Volunteer
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(new VolunteerService().GetVolunteerList());
        }

        // GET
        public ActionResult Create()
        {
            ViewBag.Title = "Volunteers";

            List<OrganizationListItem> Organizations = (new OrganizationService()).GetOrganizations().ToList();
            //Organization.Select(o => new SelectListItem() { }); may be async error, prefer this way -->
            var query = from b in Organizations
                        select new SelectListItem()
                        {
                            Value = b.OrgId.ToString(),
                            Text = b.Name
                        };
            ViewBag.OrgId = query.ToList();

            return View();
        }

        // POST: Org
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VolunteerCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new VolunteerService();

            if (service.CreateVolunteer(model))
            {
                TempData["SaveResult"] = "Volunteer was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Volunteer could not be created");

            return View(model);
        }

        // GET:
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var svc = new VolunteerService();
            var model = svc.GetVolunteerById(id);

            return View(model);
        }

        // GET:
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var service = new VolunteerService();
            var detail = service.GetVolunteerById(id);
            var model =
                new VolunteerEdit
                {
                    OrgId = detail.OrgId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName
                };

            List<OrganizationListItem> Organizations = (new OrganizationService()).GetOrganizations().ToList();

            var query = from b in Organizations
                        select new SelectListItem()
                        {
                            Value = b.OrgId.ToString(),
                            Text = b.Name
                        };
            ViewBag.OrganizationId = query.ToList();
            return View(model);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VolunteerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.OrgId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new VolunteerService();

            if (service.UpdateVolunteer(model))
            {
                TempData["SaveResult"] = "volunteer was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "volunteer could not be updated.");
            return View(model);
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = new VolunteerService();
            var model = svc.GetVolunteerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteVolunteer(int id)
        {
            var service = new VolunteerService();
            service.DeleteVolunteer(id);
            TempData["SaveResult"] = "volunteer was deleted";
            return RedirectToAction("Index");
        }
    }
}
