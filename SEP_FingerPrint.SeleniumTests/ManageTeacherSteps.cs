using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SEP_FingerPrint.SeleniumTests
{
    [Binding]
    public class ManageTeacherSteps
    {
        public IWebDriver driver;
        [Given(@"I log in admin account")]
        public void GivenILogInAdminAccount()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:49354");
            driver.Navigate().GoToUrl("http://localhost:49354/Home/Login");
            driver.FindElement(By.XPath("//*[@id='UserName']")).SendKeys("admin");
            driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys("123456");
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/div[5]/button")).Click();
        }              
        
        [Then(@"the list of teacher show off")]
        public void ThenTheListOfTeacherShowOff()
        {            
            driver.Url.CompareTo("http://fams.gear.host/Admin/Teach");
            driver.Close();
        }
    }
}
