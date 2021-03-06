﻿using SEP_FingerPrint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEP_FingerPrint.Common;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace SEP_FingerPrint.Controllers
{
    public class HomeController : Controller
    {
        Sep2018Entities db = new Sep2018Entities();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModels model)
        {
            if (ModelState.IsValid)
            {
                var result = Login(model.UserName, MD5Hash(model.Password));
                if (result == 1)
                {
                    var userSession = new UserLogin();
                    Session.Add("USER_SESSION", userSession);
                    var user = GetByID(model.UserName);
                    var pass = MD5Hash(model.Password);
                    var userdetail = db.TaiKhoans.Where(x => x.TenTK == model.UserName && x.matkhau == pass).FirstOrDefault();
                    Session["ID"] = userdetail.ID;
                    Session["TenTK"] = userdetail.TenTK;
                    Session["pass"] = model.Password;
                    Session["Role"] = userdetail.Vaitro;
                    if (Session["Role"].Equals(1))
                    {
                        Session["MGV"] = db.GiangViens.FirstOrDefault(x => x.IDTaiKhoan == userdetail.ID).MGV;
                        Session["TenGV"] = db.GiangViens.FirstOrDefault(x => x.IDTaiKhoan == userdetail.ID).HoTen;
                        Session["Clr0"] = db.CauHinhs.FirstOrDefault(x => x.ID == userdetail.ID).Absent;
                        Session["Clr1"] = db.CauHinhs.FirstOrDefault(x => x.ID == userdetail.ID).Attend;
                        return RedirectToAction("Course", "Lecturer");
                    }
                    else if (Session["Role"].Equals(2))
                    {
                        return RedirectToAction("Teach", "Admin");
                    }
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng.");
                }
            }
            return View(model);
        }
        public int Login(string Tentk, string passWord)
        {
            var result = db.TaiKhoans.SingleOrDefault(x => x.TenTK == Tentk);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Trangthai == "Disable")
                {
                    return -1;
                }
                else
                {
                    if (result.matkhau == passWord)
                        return 1;
                    else
                        return -2;
                }
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login","Home");
        }
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            //get hash result after computing it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexa digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }
        public string Insert(TaiKhoan entity)
        {
            db.TaiKhoans.Add(entity);
            db.SaveChanges();
            return entity.ID.ToString();
        }
        public TaiKhoan GetByID(string userName)
        {
            return db.TaiKhoans.SingleOrDefault(x => x.TenTK == userName);
        }
       
        
    }
}