using SEP_FingerPrint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using SEP_FingerPrint.Common;
using System.Web.Security;

namespace SEP_FingerPrint.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login(LoginModels model)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDao();
                var result = dao.Login(model.UserName, model.Password);
                if (result)
                {
                    var user = dao.GetByID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.TenTK;
                    userSession.UserID = user.ID;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
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


    }
}