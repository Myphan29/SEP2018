using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SEP_FingerPrint.Models
{
    public class ResetPasswordModel
    {
        [Key]
        [Required(ErrorMessage = "Mời nhập lại mật khẩu")]
        [StringLength(100, ErrorMessage = "{0} phải có ít nhât {2} kí tự.", MinimumLength = 6)]
        [Display(Name = "Mật khẩu:")]
        public string matkhau { set; get; }

        [Required(ErrorMessage = "Mời nhập lại mật khẩu")]      
        [Compare("matkhau", ErrorMessage = "Mật khẩu không khớp.")]
        [Display(Name = "Mật khẩu:")]
        public string nhaplaimatkhau { set; get; }
    }
}