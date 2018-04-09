using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEP_FingerPrint.Models
{
    public class LoginModels
    {
        public string UserName { set; get; }
        public string Password { set; get; }
        public string RememberMe { get; set; }
    }
}