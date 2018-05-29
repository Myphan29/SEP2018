using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SEP_FingerPrint.SeleniumTests
{
    [Binding]
    public sealed class ChangePasswordSteps
    {
        public IWebDriver driver = new ChromeDriver();
        [Given(@"User is at Change Password page")]
        public void GivenUserIsAtTheChangePasswordPage()
        {
            driver.Navigate().GoToUrl("http://localhost:49354/Lecturer/ChangePassword");
        }
        [When(@"User enter Old Password = 123456 And New Password = 123456789 And Confirm New Password =123456789")]
        public void WhenUserEnterOldPasswordAndNewPasswordAndConfirmNewPassword()
        {
            driver.FindElement(By.XPath("//*[@id='OldPassword']")).SendKeys("123456");
            driver.FindElement(By.XPath("//*[@id='NewPassword']")).SendKeys("123456789");
            driver.FindElement(By.XPath("//*[@id='ConfirmPassword']")).SendKeys("123456789");
            driver.FindElement(By.XPath("//*[@id='main - wrapper']/div[3]/div[2]/form/div[4]/div/input")).Click();
        }
        [When(@"User enter Old Password = 1234567 ")]
        public void WhenUserEnterWrongOldPassword()
        {
            driver.FindElement(By.XPath("//*[@id='OldPassword']")).SendKeys("1234567");
            driver.FindElement(By.XPath("//*[@id='NewPassword']")).SendKeys("123456789");
            driver.FindElement(By.XPath("//*[@id='ConfirmPassword']")).SendKeys("123456789");
            driver.FindElement(By.XPath("//*[@id='main - wrapper']/div[3]/div[2]/form/div[4]/div/input")).Click();
        }

        [When(@"User enter New Password = 1 and Confirm New Password = 1 ")]
        public void WhenUserEnterWrongPasswordCondition()
        {
            driver.FindElement(By.XPath("//*[@id='OldPassword']")).SendKeys("123456");
            driver.FindElement(By.XPath("//*[@id='NewPassword']")).SendKeys("1");
            driver.FindElement(By.XPath("//*[@id='ConfirmPassword']")).SendKeys("1");
            driver.FindElement(By.XPath("//*[@id='main - wrapper']/div[3]/div[2]/form/div[4]/div/input")).Click();
        }

        [When(@"User enter Confirm New Password = 1234567")]
        public void WhenUserEnterWrongConfirmNewPassword()
        {
            driver.FindElement(By.XPath("//*[@id='OldPassword']")).SendKeys("123456");
            driver.FindElement(By.XPath("//*[@id='NewPassword']")).SendKeys("123456789");
            driver.FindElement(By.XPath("//*[@id='ConfirmPassword']")).SendKeys("1234567");
            driver.FindElement(By.XPath("//*[@id='main - wrapper']/div[3]/div[2]/form/div[4]/div/input")).Click();
        }

        [When(@"User enter Old Password = 123456 And New Password = 123456 ")]
        public void WhenUserEnterSamePasswordOnOldPasswordAndNewPassword()
        {
            driver.FindElement(By.XPath("//*[@id='OldPassword']")).SendKeys("123456");
            driver.FindElement(By.XPath("//*[@id='NewPassword']")).SendKeys("123456");
            driver.FindElement(By.XPath("//*[@id='ConfirmPassword']")).SendKeys("123456");
            driver.FindElement(By.XPath("//*[@id='main - wrapper']/div[3]/div[2]/form/div[4]/div/input")).Click();
        }
        [Then(@"I can see success message Đổi mật khẩu thành công")]
        public void ThenICanSeeSuccessMessage()
        {

            string expectedResult = "Đổi mật khẩu thành công";
            string actualResult = driver.FindElement(By.XPath("//*[@id='main - wrapper']/div[3]/div[2]/form/div[5]/div")).Text;
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Then(@"Appear message ""(.*)"" because wrong Old Password")]
        public void ThenAppearMessageBecauseWrongOldPassword(string p0)
        {

            string expectedResult = p0;
            string actualResult = driver.FindElement(By.XPath("//*[@id='main - wrapper']/div[3]/div[2]/form/div[5]/div")).Text;
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Then(@"Appear message ""(.*)"" because wrong password condition")]
        public void ThenAppearMessageBecauseWrongPasswordCondition(string p0)
        {

            string expectedResult = p0;
            string actualResult = driver.FindElement(By.XPath("//*[@id='main - wrapper']/div[3]/div[2]/form/div[5]/div")).Text;
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Then(@"Appear message ""(.*)"" because wrong Confirm Password")]
        public void ThenAppearMessageBecauseWrongConfirmNewPassword(string p0)
        {

            string expectedResult = p0;
            string actualResult = driver.FindElement(By.XPath("//*[@id='main - wrapper']/div[3]/div[2]/form/div[5]/div")).Text;
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Then(@"Appear message ""(.*)"" because Old and New same password")]
        public void ThenAppearMessageBecauseOldAndNewSamePassword(string p0)
        {

            string expectedResult = p0;
            string actualResult = driver.FindElement(By.XPath("//*[@id='main - wrapper']/div[3]/div[2]/form/div[5]/div")).Text;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
