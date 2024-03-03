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
    public class MailSubController : Controller
    {

        KidKinderContext db = new KidKinderContext();

        // GET: MailSub
        public ActionResult Index()
        {
            var values = db.MailSubscribes.ToList();
            return View(values);
        }

        public ActionResult Delete(int id)
        {

            var value = db.MailSubscribes.Find(id);
            db.MailSubscribes.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}