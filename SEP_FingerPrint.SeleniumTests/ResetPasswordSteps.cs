using System;
using TechTalk.SpecFlow;
using OpenQA;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace SEP_FingerPrint.SeleniumTests
{
    [Binding]
    public class ResetPasswordSteps
    {
        public IWebDriver _driver = new ChromeDriver();
        [Given(@"I was in the Login view")]
        public void GivenIWasInTheLoginView()
        {
            _driver.Url = "http://localhost:49354";
        }
        
        [Given(@"I filled the username and password field")]
        public void GivenIFilledTheUsernameAndPasswordField()
        {
            _driver.FindElement(By.XPath("//*[@id='UserName']")).SendKeys("admin");
            _driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys("123456");
        }
        
        [Given(@"I press Login")]
        public void GivenIPressLogin()
        {
            _driver.FindElement(By.XPath("//*[@id='login']")).Click();
        }
        
        [Given(@"I should be Logged in and arrive at admin profile view")]
        public void GivenIShouldBeLoggedInAndArriveAtAdminProfileView()
        {
            _driver.Url = "http://localhost:49354/Admin/Teach";
        }
        
        [When(@"I press reset password of user")]
        public void WhenIPressResetPasswordOfUser()
        {
            _driver.FindElement(By.XPath("//*[@id='listGV']/tbody/tr[1]/td[5]/a")).Click(); //MH
        }
        
        [When(@"I fill new password")]
        public void WhenIFillNewPassword()
        {
            _driver.FindElement(By.XPath("//*[@id='matkhau']")).SendKeys("123456789");
        }
        
        [When(@"I fill password confirmation")]
        public void WhenIFillPasswordConfirmation()
        {
            _driver.FindElement(By.XPath("//*[@id='nhaplaimatkhau']")).SendKeys("123456789");
        }
        
        [When(@"I click change password button")]
        public void WhenIClickChangePasswordButton()
        {
            _driver.FindElement(By.XPath("//*[@id='button']")).Click();
        }
        
        [When(@"I fill new password doesn't match condition")]
        public void WhenIFillNewPasswordDoesnTMatchCondition()
        {
            _driver.FindElement(By.XPath("//*[@id='matkhau']")).SendKeys("123");
        }
        
        [When(@"I click reset password button")]
        public void WhenIClickResetPasswordButton()
        {
            _driver.FindElement(By.XPath("//*[@id='button']")).Click();
        }
        
        [When(@"I fill password confirmation doesn't match new password")]
        public void WhenIFillPasswordConfirmationDoesnTMatchNewPassword()
        {
            _driver.FindElement(By.XPath("//*[@id='nhaplaimatkhau']")).SendKeys("1234567");
        }
        
        [When(@"I fill new password nothing")]
        public void WhenIFillNewPasswordNothing()
        {
            _driver.FindElement(By.XPath("//*[@id='matkhau']")).SendKeys("");
        }
        
        [When(@"I fill password confirmation nothing")]
        public void WhenIFillPasswordConfirmationNothing()
        {
            _driver.FindElement(By.XPath("//*[@id='nhaplaimatkhau']")).SendKeys("");
        }
        
        [Then(@"I see password is changed successfully message")]
        public void ThenISeePasswordIsChangedSuccessfullyMessage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I see password is changed unsuccessfully message")]
        public void ThenISeePasswordIsChangedUnsuccessfullyMessage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
