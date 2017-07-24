namespace Website.Automation.Tests.Browsers
{
    using Coypu.Drivers;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;

    public class InternetExplorerWrapper : Coypu.Drivers.Selenium.SeleniumWebDriver
    {
        public static IWebDriver IECoypuDriver { get; set; }

        public InternetExplorerWrapper(): base(GetWebDriver(), Browser.InternetExplorer)
        {

        }

        public InternetExplorerWrapper(Browser browserName) : base(GetWebDriver(), browserName)
        {

        }

        private static IWebDriver GetWebDriver()
        {
            var options = new InternetExplorerOptions()
            {
                //Add any arguments based on your network/project/your needs.
                UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Dismiss,
            };
            options.UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Ignore;
            var service = InternetExplorerDriverService.CreateDefaultService();
            IECoypuDriver = new InternetExplorerDriver(service, options);
            return IECoypuDriver;
        }
    }
}
