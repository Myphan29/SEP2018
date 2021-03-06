﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Linq;

namespace SEP_FingerPrint.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu cũ")]
        [Required(ErrorMessage = "Hãy nhập mật khẩu cũ")]
        public string OldPassword { set; get; }

        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu mới")]
        [Required(ErrorMessage = "Hãy nhập mật khẩu mới")]
        [StringLength(100, ErrorMessage = "Ít nhất 6 kí tự", MinimumLength = 6)]
        public string NewPassword { set; get; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Hãy nhập lại mật khẩu mới")]
        [Display(Name = "Xác nhận lại mật khẩu mới")]
        [Compare("NewPassword", ErrorMessage = "Nhập lại mật khẩu không chính xác")]
        [StringLength(100, ErrorMessage = "Ít nhất 6 kí tự", MinimumLength = 6)]
        public string ConfirmPassword { set; get; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}