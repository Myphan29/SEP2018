using Microsoft.AspNet.Identity;
using PagedList;
using SEP_FingerPrint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var ImportTeacherAfterCreateAccount = new GiangVien();
            var ImportTeacherConfig = new CauHinh();
            if (ModelState.IsValid)
            {
                using (Sep2018Entities db = new Sep2018Entities())
                {
                    //int LastestID = db.TaiKhoans.Max(k => k.ID);
                    if (db.TaiKhoans.Any(x => x.TenTK == model.TenTK))
                    {
                        //ViewBag.DuplicateMessage = "This name has already used.";
                        ModelState.AddModelError("", "Tài khoản đã tồn tại");
                        return View("AddUser", model);
                    }
                    if (model.matkhau == model.nhaplaimatkhau)
                    {
                        user.HoTen = model.HoTen;
                        //model.ID = LastestID + 1;
                        user.TenTK = model.TenTK;
                        //user.matkhau = Crypto.Hash(model.matkhau);
                        user.matkhau = HomeController.MD5Hash(model.matkhau);
                        user.Vaitro = model.Vaitro;
                        user.Trangthai = model.Trangthai;
                        //user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                        db.TaiKhoans.Add(user);
                        db.SaveChanges();
                        int ID_Keeper = user.ID;
                        // Import teacher account & configuration
                        if (user.Vaitro == 1)
                        {
                            // assign account
                            ImportTeacherAfterCreateAccount.IDTaiKhoan = ID_Keeper;
                            int x = ImportTeacherAfterCreateAccount.IDTaiKhoan;
                            ImportTeacherAfterCreateAccount.IDConf = ID_Keeper;
                            int y = ImportTeacherAfterCreateAccount.IDConf;
                            ImportTeacherAfterCreateAccount.HoTen = user.HoTen;
                            ImportTeacherAfterCreateAccount.MGV = model.MGV;
                            db.GiangViens.Add(ImportTeacherAfterCreateAccount);
                            // assign config
                            ImportTeacherConfig.ID = ID_Keeper;
                            int z = ImportTeacherConfig.ID;
                            ImportTeacherConfig.Attend = "#e74c3c";
                            ImportTeacherConfig.Absent = "#2ecc71";
                            db.CauHinhs.Add(ImportTeacherConfig);
                            db.SaveChanges();
                        }
                        db.SaveChanges();
                        ViewBag.SuccessMessage = "The user has been added";
                    }
                }
                ModelState.Clear();
            }
            return View("AddUser", new Account());
        }
        [HttpGet]
        public ActionResult Edit()
        {
            var user = db.GiangViens.OrderBy(x => x.IDTaiKhoan).ToList();
            return View(user);
        }

        [HttpPost]
        public JsonResult ChangeStatus(Int32 id)
        {
            var result = changeStt(id);
            return Json(new
            {
                status = result
            });
        }

        public string changeStt(Int32 id)
        {
            var user = db.TaiKhoans.Find(id);
            if (user.Trangthai == "Enable")
            {
                user.Trangthai = "Disable";
            }
            else if (user.Trangthai == "Disable")
            {
                user.Trangthai = "Enable";
            }
            db.SaveChanges();
            return user.Trangthai;
        }

        

        [HttpGet]
        public ActionResult ResetPassword(string id)
        {            
            return View();
        }
        [HttpPost]
        public ActionResult ResetPassword(int id, ResetPasswordModel model)
        {
            var item = db.TaiKhoans.Where(x => x.ID == id).First();
            if (ModelState.IsValid)
            {
                if (model.matkhau == model.nhaplaimatkhau)
                {
                    item.matkhau = HomeController.MD5Hash(model.matkhau);
                    db.SaveChanges();
                    ViewBag.SuccessMessage = "The password has been reseted";
                }
            }
            return View();
        }
        public ActionResult Teach()
        {
            string idTK = Session["ID"] as string;
            var model = db.KhoaHocs.ToList();
            return View(model);
        }
        
    }
}