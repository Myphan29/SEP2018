using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEP_FingerPrint.Common
{
    [Serializable]
    public class UserLogin
    {
        public string UserID { set; get; }
        public string UserName { set; get; }
        //public int? Role { set; get; }
    }
}