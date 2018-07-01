using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SEP_FingerPrint.Models
{
    public class CreateSchedule
    {
        [Required(ErrorMessage = "Mã khóa học?")]
        //[Display(Name = "Tên đăng nhập:")]
        public string CourseID { set; get; }

        [Required(ErrorMessage = "Giờ bắt đầu?")]
        //[Display(Name = "Tên đăng nhập:")]
        public TimeSpan Start { set; get; }

        [Required(ErrorMessage = "Giờ kết thúc?")]
        //[Display(Name = "Tên đăng nhập:")]
        public TimeSpan End { set; get; }

        [Required(ErrorMessage = "Ngày bắt đầu - ngày kết thúc?")]
        //[Display(Name = "Tên đăng nhập:")]
        public DateTime DateStart { set; get; }
        public DateTime DateEnd { set; get; }

        [Required(ErrorMessage = "Thứ?")]
        //[Display(Name = "Tên đăng nhập:")]
        public int Days { set; get; }

        [Required(ErrorMessage = "Phòng học?")]
        //[Display(Name = "Tên đăng nhập:")]
        public string Room { set; get; }
        public string MGV { get; set; }
    }
}