namespace Website.Automation.Tests.Steps
{
    using Coypu;
    using TechTalk.SpecFlow;
    using Helpers;
    using PageObjects;

    [Binding]
    public sealed class MonitoringSteps
    {
        private MyFirstPageObject firstPageObject;
        private MySecondPageObject secondPageObject;
        private BrowserSession session;

        [Given(@"I enter url in '(.*)' browser")]
        public void GivenIEnterUrlInBrowser(string browserName)
        {
            firstPageObject = new MyFirstPageObject(browserName);
            firstPageObject.LoadBrowser("https://www.google.co.uk");
            session = SpecFlowTestContext.GetValue<BrowserSession>();
        }

        [When(@"I am on google search page")]
        public void WhenIAmOnGoogleSearchPage()
        {
            firstPageObject.IsOnScreen();
        }

        [When(@"I click on sign-in")]
        public void WhenIClickOnSign_In()
        {
            firstPageObject.ClickOnLink("gb_70");
        }

        [Then(@"I verify i am on sign in page")]
        public void ThenIVerifyIAmOnSignInPage()
        {
            secondPageObject = new MySecondPageObject(session);
            secondPageObject.IsOnScreen();
        }
    }
}
