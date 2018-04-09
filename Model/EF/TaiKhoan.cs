namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [StringLength(10)]
        public string ID { get; set; }

        [StringLength(50)]
        public string TenTK { get; set; }

        [StringLength(50)]
        public string matkhau { get; set; }

        public int? Vaitro { get; set; }

        [StringLength(10)]
        public string Trangthai { get; set; }
    }
}
