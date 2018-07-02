using System;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEP_FingerPrint.Controllers;
using SEP_FingerPrint.Models;
using SEP_FingerPrint.UnitTests.Support;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace SEP_FingerPrint.UnitTests
{
    [TestClass]
    public class ChangeStatus
    {
        [TestMethod]
        public void ValidateAdminCanChangeStatusOfAccountUser()
        {
          
            var controller = new AdminController();
            var user = new TaiKhoan
            {
                ID = 37,
                Trangthai = "Disable",
            };
          
            var validationResults = TestModelHelper.ValidateModel(controller, user);


            var result = controller.changeStt(user.ID);
            
            var viewResult = controller.Edit() as ViewResult;

            Assert.IsNotNull(viewResult);
            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual(result, "Enable");
            
        }
        
    }
}
