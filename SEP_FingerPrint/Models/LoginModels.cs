using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEP_FingerPrint.Models
{
    public class LoginModels
    {
        [Required(ErrorMessage ="Hãy điền tên tài khoản")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Hãy điền mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { set; get; }
    }
}