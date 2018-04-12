using SEP_FingerPrint.Models;
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
        SepEntities db = new SepEntities();
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
                if (result)
                {
                    var userSession = new UserLogin();
                    Session.Add("USER_SESSION", userSession);
                    var user = GetByID(model.UserName);

                    userSession.UserID = user.ID;
                    userSession.UserName = user.TenTK;
                    userSession.Role = user.Vaitro;

                    return RedirectToAction("Schedule", "Lecturer");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công.");
                }
            }
            return View(model);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
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
            return entity.ID;
        }
        public TaiKhoan GetByID(string userName)
        {
            return db.TaiKhoans.SingleOrDefault(x => x.TenTK == userName);
        }
        public bool Login(string userName, string passWord)
        {
            var result = db.TaiKhoans.Count(x => x.TenTK == userName && x.matkhau == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}