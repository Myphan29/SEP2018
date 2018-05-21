using System;
using TechTalk.SpecFlow;

namespace SEP_FingerPrint.SeleniumTests
{
    [Binding]
    public class LoginAndLogoutSteps
    {
        [Given(@"User is at the Login Page")]
        public void GivenUserIsAtTheLoginPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User enter UserName = '(.*)' and Password = '(.*)'")]
        public void WhenUserEnterUserNameAndPassword(string p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I can see the button đăng xuất and name of me")]
        public void ThenICanSeeTheButtonDangXuấtAndNameOfMe()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
