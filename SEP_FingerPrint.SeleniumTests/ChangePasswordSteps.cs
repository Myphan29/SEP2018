using System;
using TechTalk.SpecFlow;

namespace SEP_FingerPrint.SeleniumTests
{
    [Binding]
    public class ChangePasswordSteps
    {
        [Given(@"I was logged in")]
        public void GivenIWasLoggedIn()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press change password button")]
        public void WhenIPressChangePasswordButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I fill old and new password")]
        public void WhenIFillOldAndNewPassword()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I fill wrong old pass and new pass")]
        public void WhenIFillWrongOldPassAndNewPass()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I fill old and new wrong condition new password")]
        public void WhenIFillOldAndNewWrongConditionNewPassword()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I fill all but new pass and confirm aren't the same")]
        public void WhenIFillAllButNewPassAndConfirmArenTTheSame()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I fill old and new aren't the same")]
        public void WhenIFillOldAndNewArenTTheSame()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The password should be changed")]
        public void ThenThePasswordShouldBeChanged()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The password shouldn't be changed")]
        public void ThenThePasswordShouldnTBeChanged()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
