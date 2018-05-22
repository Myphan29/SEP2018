using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEP_FingerPrint.Controllers;
using SEP_FingerPrint.Models;
using SEP_FingerPrint.UnitTests.Support;
using System.Web.Mvc;

namespace SEP_FingerPrint.UnitTests
{
    [TestClass]
    public class AddUserTest
    {
        [TestMethod]
        public void ValidateLogInCredential_RoleGiangVien_WithValidCredential_ExpectValidCredential()
        {
            //Arrange
            var controller = new AdminController();
            var user = new Account
            {
                HoTen = "Ly Thi Huyen Chau",
                TenTK = "T150010",
                matkhau = "123456",
                nhaplaimatkhau = "123456",
                Vaitro = 1,
                Trangthai = "Khoa"
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);
            //Act
            var viewResult = controller.AddUser(user) as ViewResult;
            //Assert
            Assert.IsNotNull(viewResult);
            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
            Assert.AreEqual(0, validationResults.Count);
        }
        [TestMethod]
        public void ValidateLogInCredential_RoleGiaoVu_WithValidCredential_ExpectValidCredential()
        {
            //Arrange
            var controller = new AdminController();
            var user = new Account
            {
                TenTK = "admin1",
                matkhau = "123456",
                nhaplaimatkhau = "123456",
                Vaitro = 2,
                Trangthai = "Khoa"
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);
            //Act
            var viewResult = controller.AddUser(user) as ViewResult;
            //Assert
            Assert.IsNotNull(viewResult);
            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
            Assert.AreEqual(0, validationResults.Count);
        }
        [TestMethod]
        public void ValidateLogInCredential_RoleGiangVien_WithInValidConfirmPassword_ExpectInValidConfirmPassword()
        {
            //Arrange
            var controller = new AdminController();
            var user = new Account
            {
                HoTen = "Ly Thi Huyen Chau",
                TenTK = "T150010",
                matkhau = "1",
                nhaplaimatkhau = "123456",
                Vaitro = 1,
                Trangthai = "Khoa"
            };
            var validationResults = TestModelHelper.ValidateModel(controller, user);
            //Act
            var viewResult = controller.AddUser(user) as ViewResult;
            //Assert
            Assert.IsNotNull(viewResult);
            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
            Assert.AreEqual(1, validationResults.Count);
            Assert.IsTrue(validationResults[0].ErrorMessage.Equals("Mat khau khong khop"));
        }
    }
}
