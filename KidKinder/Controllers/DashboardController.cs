using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder.Models.Entities;
using KidKinder.Context;


namespace KidKinder.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()

        { ViewBag.ResimCizimCount = context.Teachers.Where(x => x.BranchID == (context.Branches.Where(y => y.BranchName == "Resim Çizim").Select(y => y.BranchID).FirstOrDefault())).Count();

            ViewBag.TotalService = context.Services.Count();
            var values = context.Teachers.GroupBy(x => x.BranchID).Select(x => new
            {
                Key = x.Key,
                Count = x.Count()
            }).OrderByDescending(x => x.Count).FirstOrDefault();

            ViewBag.MaxBranch = context.Branches.Where(x => x.BranchID == values.Key).Select(x => x.BranchName).FirstOrDefault();
            var maxbranch = context.Branches.Where(x => x.BranchID == values.Key).Select(x => x.BranchName).FirstOrDefault();
            ViewBag.MaxBranchTeacher = context.Teachers.Where(x => x.BranchID == (context.Branches.Where(y => y.BranchName == maxbranch.ToString()).Select(y => y.BranchID).FirstOrDefault())).Count();
            ViewBag.TotalBranch = context.Branches.Count();
            ViewBag.TotalMessage = context.Contacts.Count();
            ViewBag.AdminCount = context.Admins.Count();
            ViewBag.ParentCount = context.Parents.Count();

            ViewBag.RezCount = context.BookASeats.Count();
            ViewBag.BugunkuMesajSayisi = context.Contacts.Count(c => c.SendDate.Year == DateTime.Today.Year && c.SendDate.Month == DateTime.Today.Month && c.SendDate.Day == DateTime.Today.Day);


            // Contact tablosundaki IsRead durumu true olan mesaj sayısını al
            int isReadMesajSayisi = context.Contacts.Count(c => c.IsRead == true);

            // ViewBag üzerine bu bilgiyi ekleyin
            ViewBag.IsReadMesajSayisi = isReadMesajSayisi;

            // Notifications tablosundaki toplam kayıt sayısını al
            int toplamBildirimSayisi = context.Notifications.Count();

            // ViewBag üzerine bu bilgiyi ekleyin
            ViewBag.ToplamBildirimSayisi = toplamBildirimSayisi;

            // Öğrenci tablosundaki toplam kayıt sayısını al
            int toplamOgrenciSayisi = context.Students.Count();

            // ViewBag üzerine bu bilgiyi ekleyin
            ViewBag.ToplamOgrenciSayisi = toplamOgrenciSayisi;

            return View();
        }
       
    }
}