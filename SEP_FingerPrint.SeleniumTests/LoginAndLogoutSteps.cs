using System;
using TechTalk.SpecFlow;
using SEP_FingerPrint.SeleniumTests.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SEP_FingerPrint.SeleniumTests
{
    [Binding, Scope(Tag = "web")]
    public class LoginAndLogoutSteps : SeleniumStepsBase
    {

        [Given(@"User is at the Login Page")]
        public void GivenUserIsAtTheLoginPage()
        {
            Browser.NavigateTo("Login");
        }

        [When(@"User enter UserName = t(.*) and Password = (.*) of teacher")]
        public void WhenUserEnterUserNameTAndPasswordOfTeacher(int p0, int p1)
        {
            Browser.FindElement(By.XPath("//*[@id='UserName']")).SendKeys("t1500001");
            Browser.FindElement(By.XPath("//*[@id='Password']")).SendKeys("p1");
            Browser.FindElement(By.XPath("/html/body/div[1]/div/div/form/div[5]/button")).Click();

        }

        [When(@"User enter UserName = admin and Password = (.*) of admin")]
        public void WhenUserEnterUserNameAdminAndPasswordOfAdmin(int p0)
        {
            Browser.FindElement(By.XPath("//*[@id='UserName']")).SendKeys("admin");
            Browser.FindElement(By.XPath("//*[@id='Password']")).SendKeys("p0");
            Browser.FindElement(By.XPath("/html/body/div[1]/div/div/form/div[5]/button")).Click();
        }

        [When(@"User enter UserName = asdasda and Password = (.*)")]
        public void WhenUserEnterUserNameAsdasdaAndPassword(int p0)
        {
            Browser.FindElement(By.XPath("//*[@id='UserName']")).SendKeys("asdasda");
            Browser.FindElement(By.XPath("//*[@id='Password']")).SendKeys("p0");
            Browser.FindElement(By.XPath("/html/body/div[1]/div/div/form/div[5]/button")).Click();
        }

        [When(@"User enter UserName = t(.*) and Password = (.*)")]
        public void WhenUserEnterUserNameTAndPassword(int p0, Decimal p1)
        {
            Browser.FindElement(By.XPath("//*[@id='UserName']")).SendKeys("asdasda");
            Browser.FindElement(By.XPath("//*[@id='Password']")).SendKeys("p0");
            Browser.FindElement(By.XPath("/html/body/div[1]/div/div/form/div[5]/button")).Click();
        }

        [When(@"User enter UserName = t(.*) and Password = (.*) \(trạng thái: ""(.*)""\)")]
        public void WhenUserEnterUserNameTAndPasswordTrạngThai(int p0, int p1, string p2)
        {
            Browser.FindElement(By.XPath("//*[@id='UserName']")).SendKeys("t1500004");
            Browser.FindElement(By.XPath("//*[@id='Password']")).SendKeys("p1");
            Browser.FindElement(By.XPath("/html/body/div[1]/div/div/form/div[5]/button")).Click();
        }

        [When(@"User enter UserName = asdasd and Password = adsadadas")]
        public void WhenUserEnterUserNameAsdasdAndPasswordAdsadadas()
        {
            Browser.FindElement(By.XPath("//*[@id='UserName']")).SendKeys("asdasd");
            Browser.FindElement(By.XPath("//*[@id='Password']")).SendKeys("adsadadas");
            Browser.FindElement(By.XPath("/html/body/div[1]/div/div/form/div[5]/button")).Click();
        }

        [When(@"User enter UserName =  and Password = adsadadas")]
        public void WhenUserEnterUserNameAndPasswordAdsadadas()
        {
            Browser.FindElement(By.XPath("//*[@id='UserName']")).SendKeys("");
            Browser.FindElement(By.XPath("//*[@id='Password']")).SendKeys("123456");
            Browser.FindElement(By.XPath("/html/body/div[1]/div/div/form/div[5]/button")).Click();
        }

        [When(@"User enter UserName = asdasdasd and Password =")]
        public void WhenUserEnterUserNameAsdasdasdAndPassword()
        {
            Browser.FindElement(By.XPath("//*[@id='UserName']")).SendKeys("t150001");
            Browser.FindElement(By.XPath("//*[@id='Password']")).SendKeys("");
            Browser.FindElement(By.XPath("/html/body/div[1]/div/div/form/div[5]/button")).Click();
        }

        [Then(@"I can see the button đăng xuất and name of me")]
        public void ThenICanSeeTheButtonDangXuấtAndNameOfMe()
        {
            string expectedResult = "T150001";
            string actualResult = Browser.FindElement(By.XPath("//*[@id='main - wrapper']/div[2]/div/div[1]/nav/div[1]/p[1]")).Text;
            Assert.AreEqual(expectedResult, actualResult);
            string expectedResult1 = "Đăng xuất";
            string actualResult1 = Browser.FindElement(By.XPath("//*[@id='main - wrapper']/div[2]/div/div[1]/nav/div[2]/a/span")).Text;
            Assert.AreEqual(expectedResult1, actualResult1);
        }

        [Then(@"I can see the button đăng xuất and name of admin")]
        public void ThenICanSeeTheButtonDangXuấtAndNameOfAdmin()
        {
            string expectedResult = "admin";
            string actualResult = Browser.FindElement(By.XPath("//*[@id='main - wrapper']/div[2]/div/div[1]/nav/div[1]/p")).Text;
            Assert.AreEqual(expectedResult, actualResult);
            string expectedResult1 = "Đăng xuất";
            string actualResult1 = Browser.FindElement(By.XPath("//*[@id='main - wrapper']/div[2]/div/div[1]/nav/div[2]/a/span")).Text;
            Assert.AreEqual(expectedResult1, actualResult1);
        }

        [Then(@"Appear message ""(.*)"" because wrong username")]
        public void ThenAppearMessageBecauseWrongUsername(string p0)
        {
            string expectedResult = p0;
            string actualResult = Browser.FindElement(By.XPath("//*[@id='main - wrapper']/div[2]/div/div[1]/nav/div[2]/a/span")).Text;
            Assert.AreEqual(expectedResult, actualResult);
        }
        
        [Then(@"Appear message ""(.*)"" because wrong password")]
        public void ThenAppearMessageBecauseWrongPassword(string p0)
        {
            string expectedResult = p0;
            string actualResult = Browser.FindElement(By.XPath("//*[@id='main - wrapper']/div[2]/div/div[1]/nav/div[2]/a/span")).Text;
            Assert.AreEqual(expectedResult, actualResult);
        }
        
        [Then(@"Appear message ""(.*)"" because account was disable")]
        public void ThenAppearMessageBecauseAccountWasDisable(string p0)
        {
            string expectedResult = p0;
            string actualResult = Browser.FindElement(By.XPath("//*[@id='main - wrapper']/div[2]/div/div[1]/nav/div[2]/a/span")).Text;
            Assert.AreEqual(expectedResult, actualResult);
        }
        
        [Then(@"Appear message ""(.*)"" because account don't exist")]
        public void ThenAppearMessageBecauseAccountDonTExist(string p0)
        {
            string expectedResult = p0;
            string actualResult = Browser.FindElement(By.XPath("//*[@id='main - wrapper']/div[2]/div/div[1]/nav/div[2]/a/span")).Text;
            Assert.AreEqual(expectedResult, actualResult);
        }
        
        [Then(@"Appear message ""(.*)"" becasause user don't type username")]
        public void ThenAppearMessageBecasauseUserDonTTypeUsername(string p0)
        {
            string expectedResult = p0;
            string actualResult = Browser.FindElement(By.XPath("//*[@id='main - wrapper']/div[2]/div/div[1]/nav/div[2]/a/span")).Text;
            Assert.AreEqual(expectedResult, actualResult);
        }
        
        [Then(@"Appear message ""(.*)"" user don't type password")]
        public void ThenAppearMessageUserDonTTypePassword(string p0)
        {
            string expectedResult = p0;
            string actualResult = Browser.FindElement(By.XPath("//*[@id='main - wrapper']/div[2]/div/div[1]/nav/div[2]/a/span")).Text;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
