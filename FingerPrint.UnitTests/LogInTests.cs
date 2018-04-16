using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEP_FingerPrint.Controllers;
using SEP_FingerPrint.Models;
using System.Web.Mvc;
using SEP_FingerPrint.UnitTests.Support;

namespace FingerPrint.UnitTests
{
    [TestClass]
    public class LogInTests
    {
        [TestMethod]
        public void Login_With_True_Username_Succeeds()
        {
            var controller = new HomeController();
            var user = new LoginModels
            {
                UserName = "T150001",
                Password = "123456789"
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);

            var viewResult = controller.Login(user) as ViewResult;

            Assert.IsNotNull(viewResult);
            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
            Assert.AreEqual(2, validationResults.Count);
        }
    }
}
