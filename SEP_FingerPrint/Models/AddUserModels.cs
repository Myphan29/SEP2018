using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SEP_FingerPrint.Models
{
    public class Account
    {      
        [Required(ErrorMessage = "Mời nhập tên đăng nhập")]
        [StringLength(100, ErrorMessage = "Tên đăng nhập phải có ít nhất 6 kí tự", MinimumLength = 6)]
        [Display(Name = "Họ va` tên:")]
        public string TenTK { set; get; }

        
        [Display(Name = "Họ tên ")]
        [StringLength(100, ErrorMessage = "Họ tên phải có ít nhất 6 kí tự", MinimumLength = 7)]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        [StringLength(100, ErrorMessage = " Mật khẩu phải có ít nhất 6 kí tự", MinimumLength = 6)]
        [Display(Name = "Mật khẩu:")]
        public string matkhau { set; get; }

        [Required(ErrorMessage = "Mời nhập lại mật khẩu")]       
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