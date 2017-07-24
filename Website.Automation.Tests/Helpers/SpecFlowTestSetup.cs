namespace Website.Automation.Tests.Helpers
{
    using System;
    using TechTalk.SpecFlow;
    using System.IO;
    using Coypu;
    using System.Drawing.Imaging;

    [Binding]
    public class SpecFlowTestSetup
    {
        [BeforeScenario]
        public static void BestTestScenarioRun()
        {
            //Any underconstruction stuff can go here.
        }

        [AfterScenario]
        public static void AfterScenarioRun()
        {
            using (var session = SpecFlowTestContext.GetValue<BrowserSession>())
            {
                //Any job of checking for exception on test scenario failure can be handled here.
                if(ScenarioContext.Current.TestError != null) { }

                TakeScreenShot(session);

                if(BrowserLifeCycle.CoypuDriver != null)
                {
                    BrowserLifeCycle.CoypuDriver.Dispose();
                }
            }
        }

        private static void TakeScreenShot(BrowserSession session)
        {
            var fileName = $"{ScenarioContext.Current.ScenarioInfo.Title}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}";
            var directoryInfo = Directory.GetCurrentDirectory();
            DirectoryInfo logDirectory = new DirectoryInfo(directoryInfo);
            var logLocation = logDirectory.CreateSubdirectory("Screenshots");
            var path = Path.Combine(logLocation.FullName, fileName);
            Console.WriteLine($"Screenshot at {path}");
            session.SaveScreenshot(path, ImageFormat.Jpeg);
            Console.WriteLine("Saved screen shot..");
        }
    }
}
