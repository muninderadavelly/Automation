namespace Website.Automation.Tests.PageObjects
{
    using Coypu;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class MySecondPageObject : BasePageObject
    {
        const string PageTitle = "Sign in - Google Accounts";

        public MySecondPageObject(BrowserSession session) : base(session)
        {
                        
        }

        public void IsOnScreen()
        {
            base.IsOnScreen(PageTitle);
        }
    }
}
