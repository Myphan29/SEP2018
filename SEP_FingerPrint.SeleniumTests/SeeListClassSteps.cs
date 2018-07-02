using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SEP_FingerPrint.SeleniumTests
{
    [Binding]
    public class SeeListClassSteps
    {
        public IWebDriver driver;
        [Given(@"i was login")]
        public void GivenIWasLogin()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:49354");
            driver.Navigate().GoToUrl("http://localhost:49354/Home/Login");
            driver.FindElement(By.XPath("//*[@id='UserName']")).SendKeys("phamminhhuyen");
            driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys("croprokiwi");
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/div[5]/button")).Click();
        }
        
        [Then(@"the list of class show off")]
        public void ThenTheListOfClassShowOff()
        {
            driver.Url.CompareTo("http://localhost:49354/Lecturer/Course");
            driver.Close();
        }
    }
}
