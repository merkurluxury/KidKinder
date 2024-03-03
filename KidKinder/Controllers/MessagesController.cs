using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder.Context;
using KidKinder.Models.Entities;
using System.Web.Routing;

namespace KidKinder.Controllers
{
    public class MessagesController : Controller
    {
        KidKinderContext db = new KidKinderContext();

        // GET: Messages
        public ActionResult Index()
        {
            var values = db.Contacts.OrderBy(x => x.SendDate).ToList();
            return View(values);
        }

        public ActionResult DeleteContact(int id)
        {

            var value = db.Contacts.Find(id);
            db.Contacts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MarkAsRead(int id)
        {
            var message = db.Contacts.Find(id);
            message.IsRead = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OpenMessage(int id)
        {
            var value = db.Contacts.Find(id);
            return View(value);
        }
    }
}