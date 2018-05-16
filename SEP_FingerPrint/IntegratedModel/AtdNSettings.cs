using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SEP_FingerPrint.Models;


namespace SEP_FingerPrint.IntegratedModel
{
    public class AtdNSettings
    {
        public List<DiemDanh> zDiemDanh { get; set; }
        public List<CauHinh>  zCauHinh { get; set; }  
        public List<BuoiHoc> zBuoiHoc { get; set; }
        public List<TaiKhoan> zTaiKhoan { get; set; }
        public List<GiangVien> zGiangVien { get; set; }
        public List<KhoaHoc> zKhoaHoc { get; set; }
        public List<DanhSachLop> zDanhSachLop { get; set; }
        public List<SinhVien> zSinhVien { get; set; }

    }
}