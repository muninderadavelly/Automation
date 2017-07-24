namespace Website.Automation.Tests.PageObjects
{
    using System;
    using Coypu;
    using OpenQA.Selenium;
    using Website.Automation.Tests.Helpers;

    public abstract class BasePageObject
    {
        private string browserName;
        private BrowserSession session;

        public BasePageObject(string browserName = "Firefox")
        {
            this.browserName = browserName;
        }

        public BasePageObject(BrowserSession session, string browserName = "Firefox")
        {
            this.browserName = browserName;
            this.session = session;
        }

        public BrowserSession LoadBrowser(string url)
        {
            Console.WriteLine($"Creating browser for {browserName}");
            session = BrowserLifeCycle.CreateBrowser(browserName);
            Console.WriteLine($"Created browser for {browserName}");

            Console.WriteLine("Save browser session");
            SpecFlowTestContext.SaveValue(session);
            Console.WriteLine("Saved browser session");

            Console.WriteLine($"visit {url}");
            session.Visit(url);
            Console.WriteLine("Url rendenred/visited");

            Console.WriteLine("Maximise window");
            session.MaximiseWindow();
            WaitToEnsureHtmlLoaded();
            return session;
        }

        public BrowserSession LoadBrowser(string browserName, string url)
        {
            this.browserName = browserName;
            LoadBrowser(url);
            return session;
        }

        internal void IsOnScreen(string title)
        {
            this.session.RetryUntilTimeout(() => {
                var isMatch = this.session.Title.Equals(title);
                if (!isMatch)
                {
                    throw new Exception($"Expected:{title}, Actual:{this.session.Title}");
                }
            });
        }

        #region "Any commonly used apis can go here"
        internal void ClickLink(string identifier)
        {
            this.session.RetryUntilTimeout(() => this.session.FindId(identifier).Click());
        }

        internal void ClickButton(string identifier)
        {
            this.session.RetryUntilTimeout(() => this.session.ClickButton(identifier));
        }

        internal void EnterText(string id,string value)
        {
           this.session.RetryUntilTimeout(() => this.session.FillIn(id).With(value));
        }
        
        #endregion

        private void WaitToEnsureHtmlLoaded()
        {
            this.session.RetryUntilTimeout(() => this.session.FindCss("html"));
        }
    }
}
