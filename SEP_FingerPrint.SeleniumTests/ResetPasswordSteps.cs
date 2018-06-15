using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;

namespace SEP_FingerPrint.SeleniumTests
{
    [Binding]
    public class ResetPasswordSteps
    {
        public IWebDriver driver = new ChromeDriver();
        [Given(@"I was in admin view")]
        public void GivenIWasInAdminView()
        {
            driver.Navigate().GoToUrl("localhost:49354");
            driver.FindElement(By.XPath("//*[@id='UserName']")).SendKeys("admin");
            driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys("123456");
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/div[5]/button")).Click();
        }
        
        [Given(@"I click teacher list")]
        public void GivenIClickTeacherList()
        {
            driver.FindElement(By.XPath("//*[@id='sidebarnav']/li[3]/a[3]/span")).Click();
        }
        
        [When(@"I press reset password of the user")]
        public void WhenIPressResetPasswordOfTheUser()
        {
            IWebElement element = driver.FindElement(By.Id("4"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Click().Build().Perform();
        }
        
        [When(@"I fill new password,confirmation and see the message succesfull")]
        public void WhenIFillNewPasswordConfirmationAndSeeTheMessageSuccesfull()
        {
            driver.FindElement(By.XPath("//*[@id='matkhau']")).SendKeys("123456879");
            driver.FindElement(By.XPath("//*[@id='nhaplaimatkhau']")).SendKeys("123456789");         
            driver.FindElement(By.XPath("//*[@id='0button']")).Text.CompareTo("The password has been reseted");
        }
        
        [When(@"I logout admin account")]
        public void WhenILogoutAdminAccount()
        {
            driver.FindElement(By.XPath("//*[@id='main - wrapper']/div[2]/div/div[1]/nav/div[2]/a/span")).Click();
        }
        
        [Then(@"I login by that user account successfull")]
        public void ThenILoginByThatUserAccountSuccessfull()
        {
            driver.Navigate().GoToUrl("localhost:49354");
            driver.FindElement(By.XPath("//*[@id='UserName']")).SendKeys("T150004");
            driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys("123456789");
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/div[5]/button")).Click();
            driver.Close();
        }
        
        [Then(@"I fill wrong condition new password,confirmation and see the message unsuccesfull")]
        public void ThenIFillWrongConditionNewPasswordConfirmationAndSeeTheMessageUnsuccesfull()
        {
            driver.FindElement(By.XPath("//*[@id='matkhau']")).SendKeys("123");
            driver.FindElement(By.XPath("//*[@id='nhaplaimatkhau']")).SendKeys("123");
            driver.FindElement(By.XPath("//*[@id='0button']")).Text.CompareTo("Password phải có ít nhất 6 kí tự");
            driver.Close();
        }
        
        [Then(@"I fill new password,confirmation doesn't match the password and see the message unsuccesfull")]
        public void ThenIFillNewPasswordConfirmationDoesnTMatchThePasswordAndSeeTheMessageUnsuccesfull()
        {
            driver.FindElement(By.XPath("//*[@id='matkhau']")).SendKeys("123456");
            driver.FindElement(By.XPath("//*[@id='nhaplaimatkhau']")).SendKeys("123");
            driver.FindElement(By.XPath("//*[@id='0button']")).Text.CompareTo("Mật khẩu không khớp");
            driver.Close();
        }
        
        [Then(@"I fill no new password,confirmation and see the message unsuccesfull")]
        public void ThenIFillNoNewPasswordConfirmationAndSeeTheMessageUnsuccesfull()
        {
            driver.FindElement(By.XPath("//*[@id='matkhau']")).SendKeys("");
            driver.FindElement(By.XPath("//*[@id='nhaplaimatkhau']")).SendKeys("");
            driver.FindElement(By.XPath("//*[@id='0button']")).Text.CompareTo("Mời nhập mật khẩu");
            driver.Close();
        }
    }
}
