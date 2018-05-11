using SEP_FingerPrint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Linq.Dynamic;
using System.Data.Entity;
using PagedList.Mvc;
using PagedList;

namespace SEP_FingerPrint.Controllers
{
    public class LecturerController : Controller
    {
        private Sep2018Entities db = new Sep2018Entities();
        // Schedule performance -My 
        public ActionResult Schedule(string id)
        {
            var khoabieu = db.BuoiHocs.Where(p => p.MKH == id).FirstOrDefault();
            return View(khoabieu);
        }

        public JsonResult GetEvents(string id)
        {
            var events = (from e in db.BuoiHocs.Where(p => p.MKH == id)
                          select new { e.MBH, e.Phong, e.Ngay, e.GioBatDau, e.GioKetThuc }).ToList();
            ;
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult SaveEvent(BuoiHoc e)
        {
            var status = false;
            using (Sep2018Entities dc = new Sep2018Entities())
            {
                if (Convert.ToInt32(e.MBH) > 0)
                {
                    //Update the event
                    var v = dc.BuoiHocs.Where(a => a.MBH == e.MBH).FirstOrDefault();
                    if (v != null)
                    {
                        v.Phong = e.Phong;
                        v.Ngay = e.Ngay;
                        v.GioBatDau = e.GioBatDau;
                        v.GioKetThuc = e.GioKetThuc;
                        v.MKH = e.MKH;
                    }
                }
                else
                {

                    dc.BuoiHocs.Add(e);
                }
                dc.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }
        [HttpGet]
        public ActionResult RollupEditor(string id)
        {
            var std = db.DiemDanhs.Where(x => x.MBH == id).ToList();
            return View(std);
        }
        [HttpPost]

        public JsonResult EditAtd(string id)
        {
            var pistol = AtdChanger(id);
            return Json(new
            {
                status = pistol
            });
        }
        public int AtdChanger(string id)
        {
            var editor = db.DiemDanhs.Find(id);
            if (editor.TrangThai == 0)
            {
                editor.TrangThai = 1;
            }
            else if (editor.TrangThai == 1)
            {
                editor.TrangThai = 0;
            }
            db.SaveChanges();
            return (int)editor.TrangThai;
        }

        public ActionResult Attendance(string course, string time = "1")
        {
            var atd = db.DiemDanhs.Where(x => x.BuoiHoc.MKH.Equals(course) && x.MBH.Equals(time)).FirstOrDefault();

            if (atd != null)
            {
                return View(atd);
            }

            return Content("<script language='javascript' type='text/javascript'>alert('Fuck off! This is not your business.');history.go(-1);</script>");
            //return HttpNotFound("");
        }


        public ActionResult FullAttendance(string course)
        {
            var atd = db.BuoiHocs.Where(x => x.MKH.Equals(course)).FirstOrDefault();
            if (atd != null)
            {
                return View(atd);
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Fuck off! This is not your business.');history.go(-1);</script>");
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
                                 Convert.ToString( c.MSV ),
                                 Convert.ToString( c.SinhVien.Ho +" "+ c.SinhVien.Ten ),
                                 Convert.ToString( c.SinhVien.GioiTinh ),
                                 Convert.ToString( c.SinhVien.NgaySinh.ToString().Split(' ')[0] ),
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

        public ActionResult LoadFullData(string course)
        {
            List<DiemDanh> _list = new List<DiemDanh>();
            try
            {
                _list = db.DiemDanhs.ToList();
                var result = from c in _list
                             where c.BuoiHoc.MKH.Equals(course)
                             select new[]
                             {
                                 Convert.ToString( c.MSV ),
                                 Convert.ToString( c.SinhVien.Ho +" "+ c.SinhVien.Ten ),
                             };
                //var result = db.DiemDanhs.Where(x => x.BuoiHoc.MKH.Equals(course)).AsEnumerable().Select(c => new
                //             {
                //                 id = Convert.ToString( c.MSV ),
                //                 name = Convert.ToString( c.SinhVien.Ho +" "+ c.SinhVien.Ten ),
                //             }).ToList();
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
            int idTK = Convert.ToInt32(Session["ID"]);
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
                    int id = Convert.ToInt32(Session["ID"]); // Get Session ID after login - HomeController for details
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