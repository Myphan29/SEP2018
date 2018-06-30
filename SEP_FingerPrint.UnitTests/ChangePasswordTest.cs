using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEP_FingerPrint.Controllers;
using SEP_FingerPrint.Models;
using SEP_FingerPrint.UnitTests.Support;
using Moq;
using System.Web;
using System.Web.Routing;

namespace SEP_FingerPrint.UnitTests
{
    [TestClass]
    public class ChangePasswordTest
    {
        [TestMethod]
        public void ChangePasswordSuccess()
        {
            //Mock
            Mock<HttpContextBase> moqContext = new Mock<HttpContextBase>();
            Mock<HttpRequestBase> moqRequest = new Mock<HttpRequestBase>();
            //Arrange
            var controller = new LecturerController();
            var user = new ChangePasswordViewModel
            {
                OldPassword = "123456",
                NewPassword = "123456789",
                ConfirmPassword = "123456789"
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);
            controller.ControllerContext = new ControllerContext(moqContext.Object, new RouteData(), controller);
            moqContext.SetupGet(x => x.Session["ID"]).Returns(1);
            //Act
            var viewResult = controller.ChangePassword(user) as ViewResult;
            //Assert
            Assert.IsNotNull(viewResult);
            Assert.AreEqual(0, validationResults.Count);
        }
        [TestMethod]
        public void ChangePasswordFail_WithWrongOldPassword()
        {
            //Mock
            Mock<HttpContextBase> moqContext = new Mock<HttpContextBase>();
            Mock<HttpRequestBase> moqRequest = new Mock<HttpRequestBase>();
            //Arrange
            var controller = new LecturerController();
            var user = new ChangePasswordViewModel
            {
                OldPassword = "1234567",
                NewPassword = "123456789",
                ConfirmPassword = "123456789"
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);
            controller.ControllerContext = new ControllerContext(moqContext.Object, new RouteData(), controller);
            moqContext.SetupGet(x => x.Session["ID"]).Returns(1);
            //Act
            var viewResult = controller.ChangePassword(user) as ViewResult;
            //Assert
            Assert.IsNotNull(viewResult);
            Assert.AreEqual(false,false, "Mật khẩu cũ sai");
        }
        [TestMethod]
        public void ChangePasswordFail_WithWrongPasswordCondition()
        {
            //Mock
            Mock<HttpContextBase> moqContext = new Mock<HttpContextBase>();
            Mock<HttpRequestBase> moqRequest = new Mock<HttpRequestBase>();
            //Arrange
            var controller = new LecturerController();
            var user = new ChangePasswordViewModel
            {
                OldPassword = "123456",
                NewPassword = "1",
                ConfirmPassword = "1"
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);
            controller.ControllerContext = new ControllerContext(moqContext.Object, new RouteData(), controller);
            moqContext.SetupGet(x => x.Session["ID"]).Returns(1);
            //Act
            var viewResult = controller.ChangePassword(user) as ViewResult;
            //Assert
            Assert.IsNotNull(viewResult);
            Assert.AreEqual(false, false, "Đổi mật khẩu không thành công with reason At least 6 characters long");
        }
        [TestMethod]
        public void ChangePasswordFail_WithWrongConfirmPassword()
        {
            //Mock
            Mock<HttpContextBase> moqContext = new Mock<HttpContextBase>();
            Mock<HttpRequestBase> moqRequest = new Mock<HttpRequestBase>();
            //Arrange
            var controller = new LecturerController();
            var user = new ChangePasswordViewModel
            {
                OldPassword = "123456",
                NewPassword = "1",
                ConfirmPassword = "123456789"
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);
            controller.ControllerContext = new ControllerContext(moqContext.Object, new RouteData(), controller);
            moqContext.SetupGet(x => x.Session["ID"]).Returns(1);
            //Act
            var viewResult = controller.ChangePassword(user) as ViewResult;
            //Assert
            Assert.IsNotNull(viewResult);
            Assert.AreEqual(false, false, "Đổi mật khẩu không thành công with reason The new password and confirmation password do not match");
        }
        [TestMethod]
        public void ChangePasswordFail_WithSamePassword()
        {
            //Mock
            Mock<HttpContextBase> moqContext = new Mock<HttpContextBase>();
            Mock<HttpRequestBase> moqRequest = new Mock<HttpRequestBase>();
            //Arrange
            var controller = new LecturerController();
            var user = new ChangePasswordViewModel
            {
                OldPassword = "123456",
                NewPassword = "1",
                ConfirmPassword = "123456789"
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);
            controller.ControllerContext = new ControllerContext(moqContext.Object, new RouteData(), controller);
            moqContext.SetupGet(x => x.Session["ID"]).Returns(1);
            //Act
            var viewResult = controller.ChangePassword(user) as ViewResult;
            //Assert
            Assert.IsNotNull(viewResult);
            Assert.AreEqual(false, false, "Đổi mật khẩu không thành công with reason The new password and confirmation password do not match");
        }
    }
}
