namespace Website.Automation.Tests.Helpers
{
    using System;
    using Coypu;
    using Coypu.Drivers;
    using OpenQA.Selenium;
    using Browsers;

    public static class BrowserLifeCycle
    {
        public static IWebDriver CoypuDriver;
        public static BrowserSession Session;

        public static BrowserSession CreateBrowser(string browserName)
        {
            var name = browserName.ToUpperInvariant();
            Session = new BrowserSession(
                new SessionConfiguration()
                {
                    Browser = Browser.Parse(name),
                    Driver = SetDriverBasedOnName(name),
                    Timeout = TimeSpan.FromMinutes(3)
                });

            //This is kind of hack for now, needs to be refactored
            //To close browser for each test scenario, either pass or fail
            //Used from the SpecFlowTestSetup.cs
            CoypuDriver = GetDriverInstance(name);

            return Session;
        }

        private static IWebDriver GetDriverInstance(string name)
        {
            switch (name)
            {
                case "CHROME":
                    return ChromeDriverWrapper.ChromeCoypuDriver;
                case "FIREFOX":
                    return FirefoxDriverWrapper.FirefoxCoypuDriver;
                case "INTERNETEXPLORER":
                    return InternetExplorerWrapper.IECoypuDriver;
                default:
                    throw new ArgumentNullException("Driver instance cannot be null");
            }
        }

        private static Type SetDriverBasedOnName(string name)
        {
            switch (name)
            {
                case "CHROME":
                    return typeof(ChromeDriverWrapper);
                case "FIREFOX":
                    return typeof(FirefoxDriverWrapper);
                case "INTERNETEXPLORER":
                    return typeof(InternetExplorerWrapper);
                default:
                    throw new NotImplementedException("Browser is not implemented/ not supported");
            }
        }
    }
}
