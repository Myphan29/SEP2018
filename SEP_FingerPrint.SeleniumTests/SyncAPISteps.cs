using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SEP_FingerPrint.SeleniumTests
{
    [Binding]
    public class SyncAPISteps
    {
        public IWebDriver driver;
        [Given(@"I was log in successfull")]
        public void GivenIWasLogInSuccessfull()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:49354");
            driver.Navigate().GoToUrl("http://localhost:49354/Home/Login");
            driver.FindElement(By.XPath("//*[@id='UserName']")).SendKeys("phamminhhuyen");
            driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys("croprokiwi");
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/div[5]/button")).Click();
        }
        
        [Given(@"I was moved to Course page")]
        public void GivenIWasMovedToCoursePage()
        {
            driver.Navigate().GoToUrl("http://localhost:49354/Lecturer/Course");
        }

        [When(@"I press button ""(.*)""")]
        public void WhenIPressButton(string p0)
        {
            driver.FindElement(By.XPath("")).Click();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            driver.Url.CompareTo("http://localhost:49354/Lecturer/Course");
            driver.Close();
        }
    }
}
