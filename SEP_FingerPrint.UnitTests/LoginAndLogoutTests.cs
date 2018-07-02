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
    [TestClass]
    public class LoginAndLogoutTests
    {
        [TestMethod]
        public void ViewLogIn()
        {
            //Arrange
            HomeController controller = new HomeController();
            //Act
            var viewResult = controller.Login() as ViewResult;
            //Assert
            Assert.IsNotNull(viewResult);
        }
        [TestMethod]
        public void LoginAdminSuccessful()
        {
            Mock<HttpContextBase> moqContext = new Mock<HttpContextBase>();
            Mock<HttpRequestBase> moqRequest = new Mock<HttpRequestBase>();
            Mock<HttpPostedFileBase> moqPostedFile = new Mock<HttpPostedFileBase>();

            moqRequest.Setup(r => r.Files.Count).Returns(0);
            moqContext.Setup(x => x.Request).Returns(moqRequest.Object);

            var controller = new HomeController();
            var user = new LoginModels()
            {
                UserName = "admin",
                Password = "123456"
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);
            controller.ControllerContext = new ControllerContext(moqContext.Object, new RouteData(), controller);

            moqContext.SetupGet(x => x.Session["ID"]).Returns(5);
            moqContext.SetupGet(x => x.Session["Role"]).Returns(2);
            var redirectRoute = controller.Login(user) as RedirectToRouteResult;

            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual("Teach", redirectRoute.RouteValues["action"]);
            Assert.AreEqual("Admin", redirectRoute.RouteValues["controller"]);
        }
        [TestMethod]
        public void LoginUserSuccessful()
        {
            Mock<HttpContextBase> moqContext = new Mock<HttpContextBase>();
            Mock<HttpRequestBase> moqRequest = new Mock<HttpRequestBase>();
            Mock<HttpPostedFileBase> moqPostedFile = new Mock<HttpPostedFileBase>();

            moqRequest.Setup(r => r.Files.Count).Returns(0);
            moqContext.Setup(x => x.Request).Returns(moqRequest.Object);

            var controller = new HomeController();
            var user = new LoginModels()
            {
                UserName = "phamminhhuyen",
                Password = "croprokiwi"
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);
            controller.ControllerContext = new ControllerContext(moqContext.Object, new RouteData(), controller);

            moqContext.SetupGet(x => x.Session["ID"]).Returns(39);
            moqContext.SetupGet(x => x.Session["Role"]).Returns(2);
            var redirectRoute = controller.Login(user) as RedirectToRouteResult;

            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual("Course", redirectRoute.RouteValues["action"]);
            Assert.AreEqual("Lecturer", redirectRoute.RouteValues["controller"]);
            
        }
        [TestMethod]
        public void LogOutSuccessful()
        {
            Mock<HttpContextBase> moqContext = new Mock<HttpContextBase>();
            Mock<HttpRequestBase> moqRequest = new Mock<HttpRequestBase>();
            Mock<HttpPostedFileBase> moqPostedFile = new Mock<HttpPostedFileBase>();

            moqRequest.Setup(r => r.Files.Count).Returns(0);
            moqContext.Setup(x => x.Request).Returns(moqRequest.Object);
            
            var controller = new HomeController();
            var user = new LoginModels()
            {
                UserName = "admin",
                Password = "123456"
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);
            
            controller.ControllerContext = new ControllerContext(moqContext.Object, new RouteData(), controller);

            moqContext.SetupGet(x => x.Session["ID"]).Returns(39);
            moqContext.SetupGet(x => x.Session["Role"]).Returns(2);
            var redirectRoute = controller.Login(user) as RedirectToRouteResult;
            var redirectRouteResult = controller.Logout() as RedirectToRouteResult;
            

            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual("Course", redirectRouteResult.RouteValues["action"]);
            Assert.AreEqual("Home", redirectRouteResult.RouteValues["controller"]);
        }
        [TestMethod]
        public void TestThatUserUnsuccessfullyLoginWithNoInputUsername()
        {
            Mock<HttpContextBase> moqContext = new Mock<HttpContextBase>();
            Mock<HttpRequestBase> moqRequest = new Mock<HttpRequestBase>();
            Mock<HttpPostedFileBase> moqPostedFile = new Mock<HttpPostedFileBase>();

            moqRequest.Setup(r => r.Files.Count).Returns(0);
            moqContext.Setup(x => x.Request).Returns(moqRequest.Object);

            var controller = new HomeController();
            var user = new LoginModels()
            {
                UserName = "",
                Password = "123456789"
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);
            controller.ControllerContext = new ControllerContext(moqContext.Object, new RouteData(), controller);
            var viewResult = controller.Login(user) as ViewResult;

            //moqContext.SetupGet(x => x.Session["ID"]).Returns(1);
            //moqContext.SetupGet(x => x.Session["Role"]).Returns(1);
            

            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
            Assert.AreEqual(1, validationResults.Count);
            Assert.IsTrue(validationResults[0].ErrorMessage.Equals("Hãy điền tên tài khoản"));
        }
        [TestMethod]
        public void TestThatUserUnsuccessfullyLoginWithNoInputPassword()
        {
            Mock<HttpContextBase> moqContext = new Mock<HttpContextBase>();
            Mock<HttpRequestBase> moqRequest = new Mock<HttpRequestBase>();
            Mock<HttpPostedFileBase> moqPostedFile = new Mock<HttpPostedFileBase>();

            moqRequest.Setup(r => r.Files.Count).Returns(0);
            moqContext.Setup(x => x.Request).Returns(moqRequest.Object);

            var controller = new HomeController();
            var user = new LoginModels()
            {
                UserName = "t150001",
                Password = ""
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);
            controller.ControllerContext = new ControllerContext(moqContext.Object, new RouteData(), controller);
            var viewResult = controller.Login(user) as ViewResult;

            //moqContext.SetupGet(x => x.Session["ID"]).Returns(1);
            //moqContext.SetupGet(x => x.Session["Role"]).Returns(1);


            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
            Assert.AreEqual(1, validationResults.Count);
            Assert.IsTrue(validationResults[0].ErrorMessage.Equals("Hãy điền mật khẩu"));
        }
        [TestMethod]
        public void TestThatUserUnsuccessfullyLoginWithInvalidPassword()
        {
            Mock<HttpContextBase> moqContext = new Mock<HttpContextBase>();
            Mock<HttpRequestBase> moqRequest = new Mock<HttpRequestBase>();
            Mock<HttpPostedFileBase> moqPostedFile = new Mock<HttpPostedFileBase>();

            moqRequest.Setup(r => r.Files.Count).Returns(0);
            moqContext.Setup(x => x.Request).Returns(moqRequest.Object);

            var controller = new HomeController();
            var user = new LoginModels()
            {
                UserName = "phamminhhuyen",
                Password = "123456"
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);
            controller.ControllerContext = new ControllerContext(moqContext.Object, new RouteData(), controller);
            var viewResult = controller.Login(user) as ViewResult;

            moqContext.SetupGet(x => x.Session["ID"]).Returns(1);
            moqContext.SetupGet(x => x.Session["Role"]).Returns(1);
            var result = controller.Login("phamminhhuyen", "123456");

            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void TestThatUserUnsuccessfullyLoginWithAccountDisabled()
        {
            Mock<HttpContextBase> moqContext = new Mock<HttpContextBase>();
            Mock<HttpRequestBase> moqRequest = new Mock<HttpRequestBase>();
            Mock<HttpPostedFileBase> moqPostedFile = new Mock<HttpPostedFileBase>();

            moqRequest.Setup(r => r.Files.Count).Returns(0);
            moqContext.Setup(x => x.Request).Returns(moqRequest.Object);

            var controller = new HomeController();
            var user = new LoginModels()
            {
                UserName = "t150003",
                Password = "123456789"
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);
            controller.ControllerContext = new ControllerContext(moqContext.Object, new RouteData(), controller);
            var viewResult = controller.Login(user) as ViewResult;

            //moqContext.SetupGet(x => x.Session["ID"]).Returns(1);
            //moqContext.SetupGet(x => x.Session["Role"]).Returns(1);
            var result = controller.Login("t150003", "123456789");

            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void TestThatUserUnsuccessfullyLoginBecauseDontHaveAccount()
        {
            Mock<HttpContextBase> moqContext = new Mock<HttpContextBase>();
            Mock<HttpRequestBase> moqRequest = new Mock<HttpRequestBase>();
            Mock<HttpPostedFileBase> moqPostedFile = new Mock<HttpPostedFileBase>();

            moqRequest.Setup(r => r.Files.Count).Returns(0);
            moqContext.Setup(x => x.Request).Returns(moqRequest.Object);

            var controller = new HomeController();
            var user = new LoginModels()
            {
                UserName = "t1555501",
                Password = "123456789"
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);
            controller.ControllerContext = new ControllerContext(moqContext.Object, new RouteData(), controller);
            var viewResult = controller.Login(user) as ViewResult;

            //moqContext.SetupGet(x => x.Session["ID"]).Returns(1);
            //moqContext.SetupGet(x => x.Session["Role"]).Returns(1);
            var result = controller.Login("t1555501", "123456789");

            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual(0, result);
        }

    }
}
