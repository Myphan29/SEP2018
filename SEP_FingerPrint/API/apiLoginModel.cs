using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEP_FingerPrint.API
{
    public class apiLoginModel
    {
        public class apiLogin
        {
            public int code { get; set; }
            public Data data { get; set; }
            public string message { get; set; }
        }

        public class Data
        {
            public string id { get; set; }
            public string secret { get; set; }
        }
    }
    

}