using SEP_FingerPrint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Linq.Dynamic;
using System.Configuration;
using System.Data.EntityClient;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.ComponentModel;
using System.Dynamic;
using SEP_FingerPrint.IntegratedModel;
using System.Globalization;
using System.Net.Http;
using Newtonsoft.Json;

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
        public JsonResult ColorChanger(CauHinh e, int id)
        {
            var status = false;
            using (Sep2018Entities gun = new Sep2018Entities())
            {
                var v = gun.CauHinhs.Where(a => a.ID == id).FirstOrDefault();
                if (v != null)
                {
                    v.Attend = e.Attend;
                    v.Absent = e.Absent;
                    Session["Clr0"] = e.Absent;
                    Session["Clr1"] = e.Attend;
                }
                gun.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }
        public ActionResult CreateSchedule(string id)
        {
            var schdl = db.GiangViens.Where(x => x.MGV == id).FirstOrDefault();
            return View(schdl);
        }
        [HttpPost]
        public JsonResult GatherScheduleData(CreateSchedule schdl)
        {
            var status = false;
           
            
             //var DateStart = (schdl.Dates.ToString().Split('-')[0]);
            //var changeDS = DateTime.Parse(DateStart.ToString().Split('/')[1] +"/"+ DateStart.ToString().Split('/')[0] +"/"+ DateStart.ToString().Split('/')[2]);
            //var DateEnd = schdl.Dates.ToString().Split('-')[1];
            //var changeDE = DateTime.Parse(DateEnd.ToString().Split('/')[1] + "/" + DateEnd.ToString().Split('/')[0] + "/" + DateEnd.ToString().Split('/')[2]);
            using (Sep2018Entities metal = new Sep2018Entities())
            {
                KhoaHoc khoahoc = metal.KhoaHocs.Single(p => p.MKH == schdl.CourseID);
                khoahoc.NgayBatDau = schdl.DateStart;
                khoahoc.NgayKetThuc = schdl.DateEnd;
                metal.SaveChanges();
                
                for (var i = schdl.DateStart; DateTime.Compare(i,schdl.DateEnd)<0; i=i.AddDays(1))
                {
                    int day = (int)i.DayOfWeek;
                    if (day == schdl.Days)
                    {
                        var B = new BuoiHoc();
                        B.MKH = schdl.CourseID;
                        B.GioBatDau = schdl.Start;
                        B.GioKetThuc = schdl.End;
                        B.Ngay = i;
                        B.Phong = schdl.Room;
                        metal.BuoiHocs.Add(B);
                        metal.SaveChanges();
                    }
                }
                
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }
        [HttpGet]
        public ActionResult Settings(int id)
        {
            var thm = db.TaiKhoans.Where(x => x.ID == id).FirstOrDefault();
            return View(thm);
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
        public ActionResult Attendance(string id, int e)    
        {
            var atd = db.DiemDanhs.Where(x => x.BuoiHoc.MKH.Equals(id) && x.MBH==e).FirstOrDefault();
            if (atd != null)
            {
                return View(atd);
            }


            return Content("<script language='javascript' type='text/javascript'>alert('Failed');history.go(-1);</script>");
        }

        public ActionResult LoadData(string id, int e)
        {
            List<DiemDanh> _list = new List<DiemDanh>();
            try
            {
                _list = db.DiemDanhs.ToList();
                var result = from c in _list
                             where c.BuoiHoc.MKH.Equals(id) && c.BuoiHoc.MBH==e
                             select new[]
                             {
                                 Convert.ToString( c.ID),
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

        public ActionResult Course()
        {
            int idTK = Convert.ToInt32(Session["ID"]);
            string mgv = db.GiangViens.ToList().FirstOrDefault(p => p.IDTaiKhoan == idTK).MGV;
            //string idGV = db.TaiKhoans.ToList().FirstOrDefault(p => p.ID == idTK).TenTK;
            return View(db.KhoaHocs.Where(p => p.MGV == mgv).ToList());
        }
        public List<KhoaHoc> initData(string mgv)
        {
            List<KhoaHoc> kh = db.KhoaHocs.Where(x => x.MGV == mgv).ToList();
            return kh;
        }

        public PartialViewResult LoadCourse()
        {
            //System.Threading.Thread.Sleep(3000); //DEMO ONLY
            int idTK = Convert.ToInt32(Session["ID"]);
            string mgv = db.GiangViens.ToList().FirstOrDefault(p => p.IDTaiKhoan == idTK).MGV;
            API.GetAPI api = new API.GetAPI();
            api.getCourse(mgv);
            var listKH = db.KhoaHocs.Where(x => x.MGV == mgv).ToList();
            foreach (var item in listKH)
            {
                api.getMember(item.MKH);
            }
            List<KhoaHoc> kh = initData(mgv);
            return PartialView("_LoadCourse", kh);
        }

        //public ActionResult postAttendance()
        //{

        //}

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel p)
        {
            if (ModelState.IsValid)
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
                        //else if (p.ConfirmPassword != p.NewPassword)
                        //{
                        //    message = "Mật khẩu mới không giống mật khẩu được xác định";
                        //    Session["CPMessage"] = message;
                        //    return View(p);
                        //}
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
            return View(p);


        }
        public List<Dictionary<string, object>> Read(DbDataReader reader)
        {
            List<Dictionary<string, object>> expandolist = new List<Dictionary<string, object>>();
            foreach (var item in reader)
            {
                IDictionary<string, object> expando = new ExpandoObject();
                foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(item))
                {
                    var obj = propertyDescriptor.GetValue(item);
                    expando.Add(propertyDescriptor.Name, obj);
                }
                expandolist.Add(new Dictionary<string, object>(expando));
            }
            return expandolist;
        }
        public ActionResult FullAttendance(string id)
        {
            Session["courseID"] = id;
            DataTable table = new DataTable();

            using (var ctx = new Sep2018Entities())
            using (var cmd = ctx.Database.Connection.CreateCommand())
            {
                ctx.Database.Connection.Open();
                cmd.CommandText = "PivotAttendance";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MKH", id));
                using (var reader = cmd.ExecuteReader())
                {
                    var model = this.Read(reader).ToList();
                    return View(model);
                }
            }
        }


        #region
        public async System.Threading.Tasks.Task<ActionResult> syncAttendanceAsync()
        {
            API.GetAPI api = new API.GetAPI();
            HttpClient client = new HttpClient();
            string id = Session["courseID"].ToString();
            string lecid = Session["MGV"].ToString();
            string sec = api.apiLogin(Session["TenTK"].ToString(), Session["pass"].ToString());

            var value = new
            {
                course = id,
                sessions = db.BuoiHocs.Where(x => x.MKH == id).AsEnumerable().Select(b => new
                {
                    id = b.MBH,
                    date = b.Ngay.ToString("yyyy-MM-ddThh:mm:ss"),
                    info = string.Empty
                }).ToArray(),
                attendance = db.DanhSachLops.AsEnumerable().Where(x => x.MKH == id).Select(d => new
                {
                    student = d.MSV,
                    checklist = db.DiemDanhs.Where(x => x.TrangThai == 1 && x.MKH == id && x.MSV == d.MSV).Select(z => z.BuoiHoc.MBH).ToArray(),
                    info = string.Empty
                }).ToArray()
            };
            var json = JsonConvert.SerializeObject(value);

            var formData = new Dictionary<string, string>
                                {
                                    { "uid", lecid },
                                    { "secret", sec },
                                    { "data", json }
                                };

            var content = new FormUrlEncodedContent(formData);
            var response = await client.PostAsync("https://entool.azurewebsites.net/SEP21/SyncAttendance", content);
            var responseString = await response.Content.ReadAsStringAsync();

            //string ResponeMessage = JsonConvert.DeserializeObject<string>(responseString);
            //	Session["SynMessage"] = ResponeMessage.message.ToString();

            //return RedirectToAction("ViewAllAttendance", new { id = Session["CourseID"] });
            return RedirectToAction("Course", "Lecturer");
        }
        #endregion
    }
}
