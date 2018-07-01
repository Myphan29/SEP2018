using System;
using TechTalk.SpecFlow;

namespace SEP_FingerPrint.SeleniumTests
{
    [Binding]
    public class ManageTeacherSteps
    {
        [Given(@"I log in admin account")]
        public void GivenILogInAdminAccount()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I go to the page admin")]
        public void GivenIGoToThePageAdmin()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the list of teacher show off")]
        public void ThenTheListOfTeacherShowOff()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
