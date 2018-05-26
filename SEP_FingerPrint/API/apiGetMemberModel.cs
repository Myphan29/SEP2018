using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEP_FingerPrint.API
{
    public class apiGetMemberModel
    {
        public class GetMembers
        {
            public int code { get; set; }
            public Data[] data { get; set; }
            public string message { get; set; }
        }

        public class Data
        {
            public string id { get; set; }
            public string fullname { get; set; }
            public string birthday { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
        }

    }
}