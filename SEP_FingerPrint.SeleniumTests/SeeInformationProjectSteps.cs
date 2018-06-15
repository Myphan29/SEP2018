using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;

namespace SEP_FingerPrint.SeleniumTests
{
    [Binding]
    public class SeeInformationProjectSteps
    {
        public IWebDriver driver = new ChromeDriver();
        [Given(@"I was loggin successfull")]
        public void GivenIWasLogginSuccessfull()
        {
            driver.Navigate().GoToUrl("localhost:49354");
            driver.FindElement(By.XPath("//*[@id='UserName']")).SendKeys("T150001");
            driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys("123456");
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/div[5]/button")).Click();            
        }
        
        [Given(@"I press button ""(.*)""")]
        public void GivenIPressButton(string p0)
        {           
            IWebElement element = driver.FindElement(By.Name("PM01"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Click().Build().Perform();
        }

        [Given(@"I see the date of course")]
        public void GivenISeeTheDateOfCourse()
        {
            driver.Navigate().GoToUrl("http://localhost:49354/Lecturer/Schedule/PM01");
        }
        
        [Given(@"I press month")]
        public void GivenIPressMonth()
        {
            driver.FindElement(By.XPath("//*[@id='calendar']/div[1]/div[2]/div/button[1]")).Click();
            IWebElement element = driver.FindElement(By.Name("PM01"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Click().Build().Perform();
        }

        [Given(@"I press week")]
        public void GivenIPressWeek()
        {
            driver.FindElement(By.XPath("//*[@id='calendar'/div[1]/div[2]/div/button[2]")).Click();           
        }

        [Given(@"I press day")]
        public void GivenIPressDay()
        {

            driver.FindElement(By.XPath("//*[@id='calendar'/div[1]/div[2]/div/button[3]")).Click();
        }
        
        [Given(@"I press list")]
        public void GivenIPressList()
        {
            driver.FindElement(By.XPath("//*[@id='calendar'/div[1]/div[2]/div/button[4]")).Click();           
        }

        [Then(@"I finally see the list")]
        public void ThenIFinallySeeTheList()
        {
            driver.Url.CompareTo("http://localhost:49354/Lecturer/Schedule/PM01");
            driver.Close();
        }
    }
}
