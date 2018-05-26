using Newtonsoft.Json;
using SEP_FingerPrint.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace SEP_FingerPrint.API
{
    public class GetAPI
    {
        Sep2018Entities db = new Sep2018Entities();
        public void getCourse(string lec_id)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(string.Format("https://entool.azurewebsites.net/SEP21/GetCourses?lecturerID=" + lec_id));
            req.Method = "GET";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            string jsonString;
            using (Stream stream = resp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            apiGetCourseModel.GetCourses courses = JsonConvert.DeserializeObject<apiGetCourseModel.GetCourses>(jsonString);
            foreach (var item in courses.data)
            {
                var mkh = item.id;
                var tenmh = item.name;

                if (db.MonHocs.Where(x => x.TenMonHoc == tenmh).Count() == 0)
                {
                    var monhoc = new MonHoc();
                    monhoc.MMH = tenmh.Substring(0,1) + tenmh.Split(' ')[1].Substring(0,1);
                    monhoc.TenMonHoc = tenmh;
                    db.MonHocs.Add(monhoc);
                    db.SaveChanges();
                }
                if (db.KhoaHocs.Where(x => x.MKH == mkh).Count() == 0)
                {
                    var khoahoc = new KhoaHoc();
                    khoahoc.MKH = mkh;
                    khoahoc.MMH = db.MonHocs.First(x => x.TenMonHoc == tenmh).MMH;
                    khoahoc.MGV = lec_id;
                    db.KhoaHocs.Add(khoahoc);
                    db.SaveChanges();
                }

                getMember(mkh);
            }
        }


        public void getMember(string course_id)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(string.Format("https://entool.azurewebsites.net/SEP21/GetMembers?courseID=" + course_id));
            req.Method = "GET";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            string jsonString;
            using (Stream stream = resp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            apiGetMemberModel.GetMembers members = JsonConvert.DeserializeObject<apiGetMemberModel.GetMembers>(jsonString);
            foreach (var item in members.data)
            {
                string mssv = item.id;
                string ho = item.lastname;
                string ten = item.firstname;
                string ngaysinh = item.birthday;

                if (db.SinhViens.Where(x => x.MSV == mssv).Count() == 0)
                {
                    var sv = new SinhVien();
                    sv.MSV = mssv;
                    sv.Ho = ho;
                    sv.Ten = ten;
                    sv.NgaySinh = DateTime.ParseExact(ngaysinh, "M/d/yyyy", null);
                    db.SinhViens.Add(sv);
                    db.SaveChanges();
                }
                if (db.DanhSachLops.Where(x => x.MSV == mssv && x.MKH == course_id).Count() == 0)
                {
                    var dslop = new DanhSachLop();
                    dslop.MSV = mssv;
                    dslop.MKH = course_id;
                    db.DanhSachLops.Add(dslop);
                    db.SaveChanges();
                }
            }
        }
    }
}