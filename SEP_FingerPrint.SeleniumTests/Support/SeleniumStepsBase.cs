using OpenQA.Selenium;

namespace SEP_FingerPrint.SeleniumTests.Support
{
    public abstract class SeleniumStepsBase
    {
// ReSharper disable InconsistentNaming
        protected IWebDriver Browser
// ReSharper restore InconsistentNaming
        {
            get { return SeleniumController.Instance.Browser; }
        }
    }
}