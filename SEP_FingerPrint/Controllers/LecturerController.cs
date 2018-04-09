using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SEP_FingerPrint.Controllers
{
    public class LecturerController : Controller
    {
        // GET: Lecturer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Schedule()
        {
            return View();
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