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
    
    public partial class KhoaHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhoaHoc()
        {
            this.BuoiHocs = new HashSet<BuoiHoc>();
            this.DanhSachLops = new HashSet<DanhSachLop>();
            this.LichHocs = new HashSet<LichHoc>();
        }
    
        public string MKH { get; set; }
        public System.DateTime NgayBatDau { get; set; }
        public System.DateTime NgayKetThuc { get; set; }
        public string HocKy { get; set; }
        public string NienKhoa { get; set; }
        public string Note { get; set; }
        public string MMH { get; set; }
        public string MGV { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BuoiHoc> BuoiHocs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhSachLop> DanhSachLops { get; set; }
        public virtual GiangVien GiangVien { get; set; }
        public virtual MonHoc MonHoc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichHoc> LichHocs { get; set; }
    }
}