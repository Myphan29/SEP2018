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
    
    public partial class LichHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LichHoc()
        {
            this.BuoiHocs = new HashSet<BuoiHoc>();
        }
    
        public string MLH { get; set; }
        public Nullable<int> Thu { get; set; }
        public Nullable<System.TimeSpan> GioBatDau { get; set; }
        public Nullable<System.TimeSpan> GioKetThuc { get; set; }
        public string MKH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BuoiHoc> BuoiHocs { get; set; }
        public virtual KhoaHoc KhoaHoc { get; set; }
    }
}
