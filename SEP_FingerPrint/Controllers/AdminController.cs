using PagedList;
using SEP_FingerPrint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace SEP_FingerPrint.Controllers
{
    public class AdminController : Controller
    {
        private Sep2018Entities db = new Sep2018Entities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
        public ActionResult AddUser()
        {
            return View();
        }
        //[HttpGet]
        //public ActionResult AddUser(int id = 0)
        //{
        //    TaiKhoan userx = new TaiKhoan();
        //    return View(userx);
        //}

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(Account model)
        {
            var user = new TaiKhoan();
            if (ModelState.IsValid)
            {
                using (Sep2018Entities db = new Sep2018Entities())
                {
                    if (db.TaiKhoans.Any(x => x.TenTK == user.TenTK))
                    {
                        ViewBag.DuplicateMessage = "This name has already used.";
                        return View("AddUser", user);
                    }
                    if (model.matkhau == model.nhaplaimatkhau)
                    {
                      //  user.ID = model.ID;
                        user.TenTK = model.TenTK;
                        user.matkhau = Crypto.Hash(model.matkhau);
                        user.Vaitro = model.Vaitro;
                        user.Trangthai = model.Trangthai;
                        //user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                        db.TaiKhoans.Add(user);
                        db.SaveChanges();
                    }
                }
                ModelState.Clear();
                ViewBag.SuccessMessage = "The user has been added";
            }
            return View("AddUser", new Account());
        }

    }
}