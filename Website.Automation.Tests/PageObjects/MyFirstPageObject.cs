namespace Website.Automation.Tests.PageObjects
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class MyFirstPageObject : BasePageObject
    {
        const string PageTitle = "Google";
        public MyFirstPageObject(string browserName) : base(browserName)
        {
        }

        public void IsOnScreen()
        {
            base.IsOnScreen(PageTitle);
        }

        internal void EnterSearchTerm(string searchTerm)
        {
            base.EnterText("lst-ib", searchTerm);
        }

        internal void ClickOnLink(string id)
        {
            base.ClickLink(id);
        }
    }
}
