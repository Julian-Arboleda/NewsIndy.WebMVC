using Microsoft.AspNet.Identity;
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
    public class MessageController : Controller
    {
        private MessageService CreateMessageService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MessageService(userId);
            return service;
        }

        // GET: Message
        [AllowAnonymous]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MessageService(userId);
            var model = service.GetMessages();

            return View(model);
        }

        [AllowAnonymous]
        public IEnumerable<MessageListItem> GetMessageList()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Messages.Select(o => new MessageListItem
                {
                    MessageId = o.MessageId,
                    Subject = o.Subject,
                    Content = o.Content,
                    DateCreated = o.DateCreated,
                    ModifiedDateCreated = o.ModifiedDateCreated
                });

                return query.ToArray();
            }
        }

      

        // GET
        public ActionResult Create()
        {
            ViewBag.Title = "Messages";
            return View();
        }

        // POST: Message
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MessageCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateMessageService();

            if (service.CreateMessage(model))
            {
                TempData["SaveResult"] = "Your message was created. ";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Message could not be created.");

            return View(model);
        }

        // GET: Details
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var svc = CreateMessageService();
            var model = svc.GetMessageById(id);

            return View(model);
        }

        // GET: 
        public ActionResult Edit(int id)
        {
            var service = CreateMessageService();
            var detail = service.GetMessageById(id);
            var model =
                new MessageEdit
                {
                    MessageId = detail.MessageId,
                    Subject = detail.Subject,
                    Content = detail.Content,
                    DateCreated = detail.DateCreated,
                    ModifiedDateCreated = detail.ModifiedDateCreated
                };
            return View(model);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MessageEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.MessageId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMessageService();

            if (service.UpdateMessage(model))
            {
                TempData["SaveResult"] = "Your message was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your message could not be updated.");
            return View(model);

        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMessageService();
            var model = svc.GetMessageById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMessage(int id)
        {
            var service = CreateMessageService();
            service.DeleteMessage(id);
            TempData["SaveResult"] = "Your message was deleted";
            return RedirectToAction("Index");
        }
    }
}