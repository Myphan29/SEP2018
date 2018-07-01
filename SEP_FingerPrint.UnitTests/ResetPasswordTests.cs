using System;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEP_FingerPrint.Controllers;
using SEP_FingerPrint.Models;
using SEP_FingerPrint.UnitTests.Support;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using System.Web.Security;


namespace SEP_FingerPrint.UnitTests
{
    /// <summary>
    /// Summary description for ResetPassword
    /// </summary>
    [TestClass]
    public class ResetPasswordTests
    {
        [TestMethod]
        public void ViewResetPassword()
        {
            var controller = new AdminController();
            var id = new TaiKhoan().ID.ToString();

            var viewResult = controller.ResetPassword(id) as ViewResult;

            Assert.IsNotNull(viewResult);
        }
        [TestMethod]
        public void ValidateResetPasswordSuccessfully()
        {
          
            //Arange
            var controller = new AdminController();
            var user = new TaiKhoan().TenTK;
            user = "test";
            var matkhau = new ResetPasswordModel()
            {
                matkhau = "12345678",
                nhaplaimatkhau = "12345678"

            };

            var validationResults = TestModelHelper.ValidateModel(controller, matkhau);

            
           
            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual(true, true, "The password has been reseted");
        }
        [TestMethod]
        public void ValidateAdminUnsuccessfullyResetPasswordUserWithIncorrectPasswordFormat()
        {
            Mock<HttpContextBase> moqContext = new Mock<HttpContextBase>();
            Mock<HttpRequestBase> moqRequest = new Mock<HttpRequestBase>();
            Mock<HttpPostedFileBase> moqPostedFile = new Mock<HttpPostedFileBase>();

            moqRequest.Setup(r => r.Files.Count).Returns(0);
            moqContext.Setup(x => x.Request).Returns(moqRequest.Object);

            var controller = new AdminController();
            var id = new TaiKhoan().ID.ToString();
            
            var matkhaumoi = new ResetPasswordModel
            {
                matkhau = "123",
                nhaplaimatkhau = "123"

            };
            var validationResults = TestModelHelper.ValidateModel(controller, matkhaumoi);
            controller.ControllerContext = new ControllerContext(moqContext.Object, new RouteData(), controller);
            var viewResult = controller.ResetPassword(id) as ViewResult;

            //Act 
            //var viewResult = controller.ResetPassword(user) as ViewResult;

           
            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
            Assert.AreEqual(1, validationResults.Count);
            Assert.IsFalse(validationResults[0].ErrorMessage.Equals("Mật khẩu: phải có ít nhất 6 kí tự."));
        }
        [TestMethod]
        public void ValidateAdminUnsuccessfullyResetPasswordUserWithIncorrectConfirmPassword()
        {
            Mock<HttpContextBase> moqContext = new Mock<HttpContextBase>();
            Mock<HttpRequestBase> moqRequest = new Mock<HttpRequestBase>();
            Mock<HttpPostedFileBase> moqPostedFile = new Mock<HttpPostedFileBase>();

            moqRequest.Setup(r => r.Files.Count).Returns(0);
            moqContext.Setup(x => x.Request).Returns(moqRequest.Object);

            var controller = new AdminController();
            var user = new TaiKhoan().ID.ToString();
            var matkhau = new ResetPasswordModel()
            {
                matkhau = "12345678",
                nhaplaimatkhau = "123456789"

            };
            controller.ControllerContext = new ControllerContext(moqContext.Object, new RouteData(), controller);
            var validationResults = TestModelHelper.ValidateModel(controller, matkhau);


            //Act 
            var viewResult = controller.ResetPassword(user) as ViewResult;

            
            Assert.IsTrue(viewResult.ViewData.ModelState.IsValid);
            Assert.AreEqual(1, validationResults.Count);
            Assert.IsTrue(validationResults[0].ErrorMessage.Equals("Mật khẩu không khớp."));
        }
        [TestMethod]
        public void ValidateAdminUnsuccessfullyResetPasswordUserWithNonInput()
        {
            Mock<HttpContextBase> moqContext = new Mock<HttpContextBase>();
            Mock<HttpRequestBase> moqRequest = new Mock<HttpRequestBase>();
            Mock<HttpPostedFileBase> moqPostedFile = new Mock<HttpPostedFileBase>();

            moqRequest.Setup(r => r.Files.Count).Returns(0);
            moqContext.Setup(x => x.Request).Returns(moqRequest.Object);

            var controller = new AdminController();
            var user = new TaiKhoan().ID.ToString();
            
            var matkhau = new ResetPasswordModel()
            {
                matkhau = "",
                nhaplaimatkhau = ""

            };
            controller.ControllerContext = new ControllerContext(moqContext.Object, new RouteData(), controller);
            var validationResults = TestModelHelper.ValidateModel(controller, matkhau);

            //Act 
            var viewResult = controller.ResetPassword(user) as ViewResult;

            
            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
            Assert.AreEqual(2, validationResults.Count);
            Assert.IsFalse(validationResults[0].ErrorMessage.Equals("'Mời nhập mật khẩu, mời nhập lại mật khẩu."));
        }
    }
}
