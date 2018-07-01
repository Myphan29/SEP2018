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
            var user = new TaiKhoan().ID;
            user = 37;

            var validationResults = TestModelHelper.ValidateModel(controller, user);

            
           
            var result = controller.changeStt(user);
            //var stt = "Disable";
            var stt = new TaiKhoan();
            
            
            var viewResult = controller.Edit() as ViewResult;

            Assert.IsNotNull(viewResult);
            Assert.AreEqual(result, stt.Trangthai);
            Assert.AreEqual(0, validationResults.Count);
        }
        
    }
}
