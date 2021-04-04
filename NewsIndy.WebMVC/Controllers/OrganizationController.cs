using Microsoft.AspNet.Identity;
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
    }
}