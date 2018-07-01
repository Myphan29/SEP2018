using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEP_FingerPrint.API
{
    public class apiPostAttendanceModel
    {

        public class PostAttendace
        {
            public string uid { get; set; }
            public string secret { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            public string Course { get; set; }
            public Session[] Sessions { get; set; }
            public Attendance[] Attendance { get; set; }
        }

        public class Session
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public string Info { get; set; }
        }

        public class Attendance
        {
            public string Student { get; set; }
            public int[] Checklist { get; set; }
            public string Info { get; set; }
        }
    }
}