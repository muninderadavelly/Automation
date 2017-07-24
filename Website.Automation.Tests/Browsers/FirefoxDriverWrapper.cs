namespace Website.Automation.Tests.Browsers
{
    using Coypu.Drivers;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    public class FirefoxDriverWrapper : Coypu.Drivers.Selenium.SeleniumWebDriver
    {
        public static IWebDriver FirefoxCoypuDriver { get; set; }

        public FirefoxDriverWrapper(): base(GetWebDriver(), Browser.Firefox)
        {

        }

        public FirefoxDriverWrapper(Browser browserName) : base(GetWebDriver(), browserName)
        {

        }

        private static IWebDriver GetWebDriver()
        {
            var profile = new FirefoxProfile();
            //Add any arguments based on your network/project/your needs.
            profile.AcceptUntrustedCertificates = false;
            profile.AssumeUntrustedCertificateIssuer = false;
            profile.DeleteAfterUse = false;
            var binary = new FirefoxBinary();
            FirefoxCoypuDriver = new FirefoxDriver(binary, profile);
            return FirefoxCoypuDriver;
        }
    }
}
