namespace Website.Automation.Tests.Browsers
{
    using Coypu.Drivers;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public class ChromeDriverWrapper : Coypu.Drivers.Selenium.SeleniumWebDriver
    {
        public static IWebDriver ChromeCoypuDriver { get; set; }

        public ChromeDriverWrapper(): base(GetWebDriver(), Browser.Chrome)
        {

        }

        public ChromeDriverWrapper(Browser browserName) : base(GetWebDriver(), browserName)
        {

        }

        private static IWebDriver GetWebDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments(); //Add any arguments based on your network/project/ your needs.
            var service = ChromeDriverService.CreateDefaultService();
            ChromeCoypuDriver = new ChromeDriver(service, options);
            return ChromeCoypuDriver;
        }
    }
}
