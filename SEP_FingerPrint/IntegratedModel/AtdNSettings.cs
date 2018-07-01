using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SEP_FingerPrint.Models;


namespace SEP_FingerPrint.IntegratedModel
{
    public class AtdNSettings
    {
        public List<BuoiHoc> AnthrBuoiHoc { get; set; }
        public List<CauHinh> AnthrCauHinh { get; set; }
        public List<DanhSachLop> AnthrDanhSachLop { get; set; }
        public List<DiemDanh> AnthrDiemDanh { get; set; }
        public List<GiangVien> AnthrGiangVien { get; set; }
        public List<KhoaHoc> AnthrKhoaHoc { get; set; }
        
        public List<MonHoc> AnthrMonHoc { get; set; }
        public List<SinhVien> AnthrSinhVien { get; set; }
        public List<TaiKhoan> AnthrTaiKhoan { get; set; }
    }
}