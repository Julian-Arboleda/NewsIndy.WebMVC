using NewsIndy.Data;
using NewsIndy.Models;
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
            var model = new BoroughListItem[0];
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
            if (ModelState.IsValid)
            {
                
            }

            return View(model);
        }
    }
}