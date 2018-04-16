using Microsoft.VisualStudio.TestTools.UnitTesting;
using PPCRental.UnitTests.Support;
using SEP_FingerPrint.Controllers;
using SEP_FingerPrint.Models;

namespace FingerPrintTests
{
    [TestClass]
    public class LogInTests
    {
        [TestMethod]
        public void ValidateLogInCredential_WithValidCredential_ExpectValidCredential()
        {
            var controller = new HomeController();
            var user = new LoginModels
            {
                UserName="T150001",
                Password="123456789"
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);

        }
    }
}
