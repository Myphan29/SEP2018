//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SEP_FingerPrint.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DiemDanh
    {
        public string ID { get; set; }
        public Nullable<System.DateTime> Ngay { get; set; }
        public Nullable<System.TimeSpan> Gio { get; set; }
        public Nullable<int> TrangThai { get; set; }
        public string MSV { get; set; }
        public string MBH { get; set; }
        public string MKH { get; set; }
    
        public virtual BuoiHoc BuoiHoc { get; set; }
        public virtual KhoaHoc KhoaHoc { get; set; }
        public virtual SinhVien SinhVien { get; set; }
    }
}
