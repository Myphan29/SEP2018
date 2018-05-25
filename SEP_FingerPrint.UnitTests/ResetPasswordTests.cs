using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEP_FingerPrint.Controllers;
using SEP_FingerPrint.Models;
using SEP_FingerPrint.UnitTests.Support;


namespace SEP_FingerPrint.UnitTests
{
    [TestClass]
    public class ResetPasswordTests
    {
        [TestMethod]
        public void ValidateLogInCredential_WithValidCredential_ExpectValidCredential()
        {
            //Arrange
            var controller = new AdminController();
            var admin = new ADMIN
            {
                Password = "123456",
                CofirmPassword = "123456"
            };
            var validationResults = TestModelHelper.ValidateModel(controller, admin);
            //Act
            var viewResult = controller.ResetPassword(admin) as ViewResult;
            //Assert
            Assert.IsNotNull(viewResult);
            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
            Assert.AreEqual(0, validationResults.Count);
        }
        [TestMethod]
        public void ValidateLoginCredential_WithInValidCredential_ExpectValidCredential()
        {
            //Arrange
            var controller = new AdminController();
            var user = new USER
            {                
                Password = "",
                ConfirmPassword = "",               
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);
            //Act
            var viewResult = controller.ResetPassword(user) as ViewResult;
            //Assert
            Assert.IsNotNull(viewResult);
            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
            Assert.AreEqual(1, validationResults.Count);
            Assert.IsTrue(validationResults[0].ErrorMessage.Equals("This field is required."));

        }
        [TestMethod]
        public void ValidateLoginCredential_WithInValidPassword_ExpectInvalidPassword()
        {
            //Arrange
            var controller = new AdminController();
            var user = new USER
            {
               
                Password = "123",
                ConfirmPassword = "123",              
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);
            //Act
            var viewResult = controller.ResetPassword(user) as ViewResult;
            //Assert
            Assert.IsNotNull(viewResult);
            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
            Assert.AreEqual(1, validationResults.Count);
            Assert.IsTrue(validationResults[0].ErrorMessage.Equals("Mật khẩu phải ít nhất 6 kí tự"));
        }
        [TestMethod]
        public void ValidateLoginCredential_WithInValidConfirmPassword_ExpectInValidConfirmPassword()
        {
            //Arrange
            var controller = new UsersController();
            var user = new RegisterModel
            {
                Password = "123456",
                ConfirmPassword = "1234567",               
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);
            //Act
            var viewResult = controller.Register(user) as ViewResult;
            //Assert
            Assert.IsNotNull(viewResult);
            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
            Assert.AreEqual(1, validationResults.Count);
            Assert.IsTrue(validationResults[0].ErrorMessage.Equals("Your password and confirmation password do not match"));

        }
    }
}
