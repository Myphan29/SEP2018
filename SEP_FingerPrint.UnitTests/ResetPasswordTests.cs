using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEP_FingerPrint.Controllers;
using SEP_FingerPrint.Models;
using SEP_FingerPrint.UnitTests.Support;
using System.Web.Mvc;


namespace SEP_FingerPrint.UnitTests
{
    /// <summary>
    /// Summary description for ResetPassword
    /// </summary>
    [TestClass]
    public class ResetPasswordTests
    {
        [TestMethod]
        public void ValidateResetPasswordSuccessfully()
        {
          
            //Arange
            var controller = new AdminController();
            var user = new TaiKhoan().TenTK;
            user = "t150015";
            var matkhau = new ResetPasswordModel()
            {
                matkhau = "12345678",
                nhaplaimatkhau = "12345678"

            };
            var validationResults = TestModelHelper.ValidateModel(controller, matkhau);

            //Act 
            var viewResult = controller.ResetPassword(user) as ViewResult;

            Assert.IsNotNull(viewResult);
            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual(true, true, "The password has been reseted");
        }
        [TestMethod]
        public void ValidateAdminUnsuccessfullyResetPasswordUserWithIncorrectPasswordFormat()
        {
            var controller = new AdminController();
            var user = new TaiKhoan().TenTK;
            user = "t150015";
            var matkhau = new ResetPasswordModel()
            {
                matkhau = "123",
                nhaplaimatkhau = "123"

            };
            var validationResults = TestModelHelper.ValidateModel(controller, matkhau);

            //Act 
            var viewResult = controller.ResetPassword(user) as ViewResult;

            Assert.IsNotNull(viewResult);
            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
            Assert.AreEqual(1, validationResults.Count);
            Assert.IsTrue(validationResults[0].ErrorMessage.Equals("Mật khẩu: phải có ít nhất 6 kí tự."));
        }
        [TestMethod]
        public void ValidateAdminUnsuccessfullyResetPasswordUserWithIncorrectConfirmPassword()
        {
            var controller = new AdminController();
            var user = new TaiKhoan().TenTK;
            user = "t150015";
            var matkhau = new ResetPasswordModel()
            {
                matkhau = "12345678",
                nhaplaimatkhau = "123456789"

            };
            var validationResults = TestModelHelper.ValidateModel(controller, matkhau);

            //Act 
            var viewResult = controller.ResetPassword(user) as ViewResult;

            Assert.IsNotNull(viewResult);
            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
            Assert.AreEqual(1, validationResults.Count);
            Assert.IsTrue(validationResults[0].ErrorMessage.Equals("Mật khẩu không khớp."));
        }
        [TestMethod]
        public void ValidateAdminUnsuccessfullyResetPasswordUserWithNonInput()
        {
            var controller = new AdminController();
            var user = new TaiKhoan().TenTK;
            user = "t150015";
            var matkhau = new ResetPasswordModel()
            {
                matkhau = "123",
                nhaplaimatkhau = "123"

            };
            var validationResults = TestModelHelper.ValidateModel(controller, matkhau);

            //Act 
            var viewResult = controller.ResetPassword(user) as ViewResult;

            Assert.IsNotNull(viewResult);
            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
            Assert.AreEqual(1, validationResults.Count);
            Assert.IsTrue(validationResults[0].ErrorMessage.Equals("'Mời nhập mật khẩu, mời nhập lại mật khẩu."));
        }
    }
}
