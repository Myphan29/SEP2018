using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SEP_FingerPrint.Models
{
    public class Account
    {
        //[Required(ErrorMessage = "Mời nhập ID")]
        //public int ID { set; get; }

        //[Required(ErrorMessage = "Mời nhập họ tên")]
        [Display(Name = "Họ tên giảng viên:")]
        public string HoTen { set; get; }

        [Required(ErrorMessage = "Mời nhập tên đăng nhập")]
        [Display(Name = "Tên đăng nhập:")]
        public string TenTK { set; get; }

        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Mật khẩu:")]
        public string matkhau { set; get; }

        [Required(ErrorMessage = "Mời nhập lại mật khẩu")]
        [StringLength(100, ErrorMessage = "The {0} must be the same {2} characters long.", MinimumLength = 6)]
        [Compare("matkhau", ErrorMessage = "Mật khẩu không khớp.")]
        [Display(Name = "Mật khẩu:")]
        public string nhaplaimatkhau { set; get; }

        [Required(ErrorMessage = "Mời chọn vai trò")]
        [Display(Name = "Vai tro`:")]
        public int Vaitro { set; get; }

        [Required(ErrorMessage = "Mời chọn trạng thái")]
        [Display(Name = "Trạng thái:")]
        public string Trangthai { set; get; }
    }
}