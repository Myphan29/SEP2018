using System;
using System.Configuration;
using System.Diagnostics;
using OpenQA.Selenium;
using PPCRental.UITests.Selenium.Config;

namespace PPCRental.UITests.Selenium.Support
{
    public class SeleniumController
    {
        public static SeleniumController Instance = new SeleniumController();
        private IisExpressWebServer WebServer;
        public IWebDriver Browser { get; private set; }

        public string BaseUrl
        {
            get { return ConfigurationManager.AppSettings["BaseUrl"]; }
        }

        public void Start()
        {
            if (!(Browser is null))
            {
                return;
            }

            //Start web server to deploy and run app
            StartIisExpress();

            Browser = Browsers.Firefox;

            Trace("Selenium started");
        }

        public void Stop()
        {
            if (Browser is null)
            {
                return;
            }

            try
            {
                Browser.Quit();
                Browser.Dispose();
                WebServer.Stop();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc, "Selenium stop error");
            }

            Browser = null;
            Trace("Selenium stopped");
        }

        private static void Trace(string message) => Console.WriteLine($"-> {message}");

        private void StartIisExpress()
        {
            int PortNumber = int.Parse(BaseUrl.Substring((BaseUrl.LastIndexOf(':') + 1), (BaseUrl.LastIndexOf('/') - (BaseUrl.LastIndexOf(':') + 1))));

            var app = new WebApplication(ProjectLocation.FromFolder("PPCRental"), PortNumber);
            app.AddEnvironmentVariable("UITests");
            WebServer = new IisExpressWebServer(app);
            WebServer.Start("Release");
        }
    }
}