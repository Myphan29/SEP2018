using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SEP_FingerPrint.SeleniumTests
{
    [Binding]
    public class ChangeStatusSteps
    {
        public IWebDriver driver = new ChromeDriver();
        [Given(@"I was in the Login view")]
        public void GivenIWasInTheLoginView()
        {
            driver.Navigate().GoToUrl("localhost:49354");
        }
        
        [Given(@"I filled the username and password field")]
        public void GivenIFilledTheUsernameAndPasswordField()
        {
            driver.FindElement(By.XPath("//*[@id='UserName']")).SendKeys("admin");
            driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys("123456");
        }
        
        [Given(@"I press Login")]
        public void GivenIPressLogin()
        {
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/div[5]/button")).Click();
        }
        
        [Given(@"I should be Logged in and arrive at admin profile view")]
        public void GivenIShouldBeLoggedInAndArriveAtAdminProfileView()
        {
            driver.Navigate().GoToUrl("http://localhost:49354/Admin/Edit");
        }
        
        [When(@"I press acticve account of user")]
        public void WhenIPressActicveAccountOfUser()
        {
            driver.FindElement(By.XPath("//*[@id='sidebarnav']/li[3]/a[3]")).Click();
        }
        
        [When(@"I click button below status column")]
        public void WhenIClickButtonBelowStatusColumn()
        {
            driver.FindElement(By.Id("3")).Click();
        }
        
        [When(@"I click logout")]
        public void WhenIClickLogout()
        {
            driver.FindElement(By.XPath("//*[@id='main - wrapper']/div[3]/div/div[1]/nav/div[2]")).Click();
        }
        
        [When(@"I log in with that user account")]
        public void WhenILogInWithThatUserAccount()
        {
            driver.FindElement(By.XPath("//*[@id='UserName']")).SendKeys("T150003");
            driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys("123456");
        }
        
        [Then(@"I should be in that user profile view")]
        public void ThenIShouldBeInThatUserProfileView()
        {
            driver.Url.CompareTo("http://localhost:49354/Lecturer/Course");
            driver.Close();
        }
    }
}
