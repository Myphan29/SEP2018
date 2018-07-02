using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace SEP_FingerPrint.SeleniumTests
{
    [Binding]
    public class EditColorAttendanceSteps
    {
        public IWebDriver driver;
        [Given(@"I was loggedin")]
        public void GivenIWasLoggedin()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:49354");
            driver.Navigate().GoToUrl("http://localhost:49354/Home/Login");
            driver.FindElement(By.XPath("//*[@id='UserName']")).SendKeys("phamminhhuyen");
            driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys("croprokiwi");
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/div[5]/button")).Click();
        }

        [Given(@"I go to the course page")]
        public void GivenIGoToTheCoursePage()
        {
            driver.Navigate().GoToUrl("http://localhost:49354/Lecturer/Course");
        }

        [When(@"I press the button ""(.*)""")]
        public void WhenIPressTheButton(string p0)
        {
            IWebElement element = driver.FindElement(By.Id("caidat"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Click().Build().Perform();
        }

        [When(@"I go to the color page")]
        public void WhenIGoToTheColorPage()
        {
            driver.Navigate().GoToUrl("http://localhost:49354/Lecturer/Settings/40");
        }

        [When(@"I choose the color")]
        public void WhenIChooseTheColor()
        {
            IWebElement element = driver.FindElement(By.Id("but2"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Click().Build().Perform();
        }

        [When(@"I click ""(.*)""")]
        public void WhenIClick(string p0)
        {
            driver.FindElement(By.XPath("//*[@id='SaveChanges']")).Click();
        }

        [Then(@"the color is changed")]
        public void ThenTheColorIsChanged()
        {
            driver.Close();
        }
    }
}
