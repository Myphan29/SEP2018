using System.Configuration;
using System.Text;
using TechTalk.SpecFlow;
using PPCRental.UITests.Selenium.Config;

namespace PPCRental.UITests.Selenium.Support
{
    [Binding]
    public static class SeleniumSupport
    {
        private static bool ReuseWebSession
        {
            get { return ConfigurationManager.AppSettings["ReuseWebSession"] == "true"; }
        }
            
        [BeforeScenario("web")]
        public static void BeforeWebScenario()
        {
            SeleniumController.Instance.Start();
        }

        [AfterScenario("web")]
        public static void AfterWebScenario()
        {
            if (!ReuseWebSession)
                SeleniumController.Instance.Stop();
        }

        [AfterTestRun]
        public static void AfterWebFeature()
        {
            SeleniumController.Instance.Stop();
        }
    }
}