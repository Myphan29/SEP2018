using SEP_FingerPrint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SEP_FingerPrint.Models;
using System.Security.Cryptography;
using System.Text;
//using SEP_FingerPrint.Models;
using System.Linq.Dynamic;
using System.Data.Entity;

namespace SEP_FingerPrint.Controllers
{
    public class LecturerController : Controller
    {
        private SepEntities db = new SepEntities();
        // GET: Lecturer
        public ActionResult Schedule(string id)
        {
            //if (id == 0)
            //{
            //    return Redirect("Home/Index");
            //}
            var khoabieu = db.BuoiHocs.Where(p => p.MKH == id).FirstOrDefault();
            return View(khoabieu);
        }
        public ActionResult FindAll(string id)
        {
            return Json(db.BuoiHocs.Where(p => p.MKH == id).AsEnumerable().Select(e => new {
                id = Convert.ToInt32(e.MBH),
                title = e.Phong,
                start = e.Ngay.Value.ToString("yyyy/MM/dd") + "T" + e.GioBatDau.Value.ToString(),
                end = e.Ngay.Value.ToString("yyyy/MM/dd") + "T" + e.GioKetThuc.Value.ToString()

            }).ToList(), JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult Attendance(string course, string time)
        {
            var atd = db.BuoiHocs.Where(x => x.MKH.Equals(course)).FirstOrDefault();
            return View(atd);
        }

        public ActionResult LoadData(string course, string time)
        {
            List<DiemDanh> _list = new List<DiemDanh>();
            try
            {
                _list = db.DiemDanhs.ToList();
                var result = from c in _list
                             where c.BuoiHoc.MKH.Equals(course) && c.BuoiHoc.MBH.Equals(time)
                             select new[]
                             {
                                 Convert.ToString( c.ID ),
                                 Convert.ToString( c.SinhVien.Ho +" "+ c.SinhVien.Ten ),
                                 Convert.ToString( c.MBH ),
                                 Convert.ToString( c.Ngay ),
                                 Convert.ToString( c.Gio ),
                                 Convert.ToString( c.TrangThai ),
                             };
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //ErrorLogers.ErrorLog(ex);
                return Json(new
                {
                    aaData = new List<string[]> { }
                }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Course()
        {
            string idTK = Session["ID"] as string;
            string idGV = db.GiangViens.ToList().FirstOrDefault(p => p.IDTaiKhoan == idTK).MGV;
            return View(db.KhoaHocs.Where(p => p.MGV == idGV).ToList());
        }
        public ActionResult Settings()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel p)
        {
            string message = "";
            if (p.OldPassword != null && p.NewPassword != null && p.ConfirmPassword != null)
            {
                if (p.OldPassword == p.NewPassword)
                {
                    message = "Mật khẩu mới không được giống mật khẩu cũ";
                    Session["CPMessage"] = message;
                    return View(p);
                }
                else
                {
                    string id = Session["ID"] as string; // Get Session ID after login - HomeController for details
                    var user = db.TaiKhoans.FirstOrDefault(x => x.ID == id);
                    string oldpass = "";
                    byte[] buffer = Encoding.UTF8.GetBytes(p.OldPassword); // Mã hóa MD5
                    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                    buffer = md5.ComputeHash(buffer);
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        oldpass += buffer[i].ToString("x2");
                    }
                    if (user.matkhau != oldpass)
                    {
                        message = "Mật khẩu cũ sai";
                        Session["CPMessage"] = message; // Session CPMessage k tìm thấy *My*
                        return View(p);
                    }
                    else
                    {
                        string pass = "";
                        byte[] buffer1 = Encoding.UTF8.GetBytes(p.NewPassword); // Mã hóa MD5
                        MD5CryptoServiceProvider md51 = new MD5CryptoServiceProvider();
                        buffer1 = md51.ComputeHash(buffer1);
                        for (int i = 0; i < buffer1.Length; i++)
                        {
                            pass += buffer1[i].ToString("x2");
                        }
                        user.matkhau = pass;
                        db.SaveChanges();
                        message = "Đỗi mật khẩu thành công";
                        Session["CPMessage"] = message;
                        //return RedirectToAction("Course", "Lecturer");
                        return View(p);
                    }
                }
            }
            else
            {
                message = "Input all in form";
                Session["CPMessage"] = message;
                return View(p);
            }

            
        }
    }
}