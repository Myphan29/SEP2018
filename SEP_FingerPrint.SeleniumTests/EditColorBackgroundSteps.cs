using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using TechTalk.SpecFlow;

namespace SEP_FingerPrint.SeleniumTests
{
    [Binding]
    public class EditColorBackgroundSteps
    {
        public IWebDriver driver;
        [Given(@"I was login")]
        public void GivenIWasLogin()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:49354");
            driver.Navigate().GoToUrl("http://localhost:49354/Home/Login");
            driver.FindElement(By.XPath("//*[@id='UserName']")).SendKeys("phamminhhuyen");
            driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys("croprokiwi");
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/div[5]/button")).Click();
        }
        
        [Given(@"I go to course page")]
        public void GivenIGoToCoursePage()
        {
            driver.Navigate().GoToUrl("http://localhost:49354/Lecturer/Course");
        }
        
        [When(@"I press button ""(.*)""")]
        public void WhenIPressButton(string p0)
        {
            IWebElement element = driver.FindElement(By.Id("caidat"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Click().Build().Perform();
        }
        
        [When(@"I go to set color page")]
        public void WhenIGoToSetColorPage()
        {
            driver.Navigate().GoToUrl("http://localhost:49354/Lecturer/Settings/40");
        }
        
        [When(@"I choose color")]
        public void WhenIChooseColor()
        {
            IWebElement element = driver.FindElement(By.Id("but2"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Click().Build().Perform();
        }
        
        [When(@"I click save")]
        public void WhenIClickSave()
        {            
            driver.FindElement(By.XPath("//*[@id='SaveChanges']")).Click();
        }
        
        [Then(@"the color of layout attendance is changed")]
        public void ThenTheColorOfLayoutAttendanceIsChanged()
        {
            driver.Close();
        }
    }
}
