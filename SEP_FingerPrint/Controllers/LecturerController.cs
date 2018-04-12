using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SEP_FingerPrint.Models;

namespace SEP_FingerPrint.Controllers
{
    public class LecturerController : Controller
    {
        private SepEntities db = new SepEntities();
        // GET: Lecturer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Schedule(string id)
        {
            //if (id == 0)
            //{
            //    return Redirect("Home/Index");
            //}
            var khoahoc = db.KhoaHocs.Where(p => p.MKH == id).FirstOrDefault();
            return View(khoahoc);
        }
       public ActionResult FindAll(string id)
        {
            return Json(db.BuoiHocs.Where(p => p.MKH == id).AsEnumerable().Select(e => new {
                id = Convert.ToInt32(e.MBH),
                title = e.Phong,
                start = e.Ngay.Value.ToString("yyyy/MM/dd")+"T"+e.GioBatDau.Value.ToString(),
                end= e.Ngay.Value.ToString("yyyy/MM/dd") + "T" + e.GioKetThuc.Value.ToString(),

            }).ToList(), JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult Attendance()
        {
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
    }
}