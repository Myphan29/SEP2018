using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SEP_FingerPrint.Controllers;
using SEP_FingerPrint.UnitTests.Support;

namespace SEP_FingerPrint.UnitTests
{
    [TestClass]
    public class ManageTeacherViewTest
    {
        [TestMethod]
        public void ViewSuccess()
        {
            //Mock
            Mock<HttpContextBase> moqContext = new Mock<HttpContextBase>();
            Mock<HttpRequestBase> moqRequest = new Mock<HttpRequestBase>();
            //Arrange
            var controller = new AdminController();
            var expected = new List<string>();
            expected.Add("HC");
            expected.Add("MH");
            expected.Add("T150001");
            expected.Add("T150003");

            var actual = new List<string>();
            actual.Add("HC");
            actual.Add("MH");
            actual.Add("T150001");
            actual.Add("T150003");
            //Act
            controller.ControllerContext = new ControllerContext(moqContext.Object, new RouteData(), controller);
            moqContext.SetupGet(x => x.Session["ID"]).Returns(1);
            //Assert
            CollectionAssert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void ViewFail()
        {
            //Mock
            Mock<HttpContextBase> moqContext = new Mock<HttpContextBase>();
            Mock<HttpRequestBase> moqRequest = new Mock<HttpRequestBase>();
            //Arrange
            var controller = new AdminController();
            var expected = new List<string>();
            expected.Add("HC");
            expected.Add("MH");
            expected.Add("T150001");
            expected.Add("T150003");

            var actual = new List<string>();
            actual.Add("HC");
            actual.Add("MH");
            actual.Add("T150002");
            actual.Add("T150004");
            //Act
            controller.ControllerContext = new ControllerContext(moqContext.Object, new RouteData(), controller);
            moqContext.SetupGet(x => x.Session["ID"]).Returns(1);
            //Assert
            CollectionAssert.AreNotEqual(expected, actual);

        }
    }
}
