using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace SEP_FingerPrint.SeleniumTests
{
    [Binding]
    public class StaticalAttendanceSteps
    {
        public IWebDriver driver = new ChromeDriver();
        [Given(@"I was in user view")]
        public void GivenIWasInUserView()
        {
            driver.Navigate().GoToUrl("localhost:49354");
            driver.FindElement(By.XPath("//*[@id='UserName']")).SendKeys("T150001");
            driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys("123456");
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/div[5]/button")).Click();
        }
        
        [When(@"I press attendance button")]
        public void WhenIPressAttendanceButton()
        {
            IWebElement element = driver.FindElement(By.Id("PM01"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Click().Build().Perform();
        }                   
        
        [Then(@"the list of attendance show off as user want")]
        public void ThenTheListOfAttendanceShowOffAsUserWant()
        {
            driver.Url.CompareTo("http://localhost:49354/Lecturer/FullAttendance/PM01");
            driver.Close();
        }
    }
}
