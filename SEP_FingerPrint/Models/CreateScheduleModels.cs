using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SEP_FingerPrint.Models
{
    public class CreateSchedule
    {
        public string CourseID { set; get; }
        public string Start { set; get; }
        public string End { set; get; }
        public string Dates { set; get; }
        public string Days { set; get; }
        public string Room { set; get; }
    }
}