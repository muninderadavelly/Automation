namespace Website.Automation.Tests.Helpers
{
    using TechTalk.SpecFlow;

    public class SpecFlowTestContext
    {
        public static T GetValue<T>() where T : class
        {
            var key = typeof(T).FullName;

            if (ScenarioContext.Current == null && !ScenarioContext.Current.ContainsKey(key))
            {
                return default(T);
            }

            return (T)ScenarioContext.Current[key];
        }

        public static T GetValue<T>(string key)
        {
            if (ScenarioContext.Current == null && !ScenarioContext.Current.ContainsKey(key))
            {
                return default(T);
            }

            return (T)ScenarioContext.Current[key];
        }

        public static T SaveValue<T>(T value) where T : class
        {
            if (ScenarioContext.Current == null)
            {
                return null;
            }

            var key = typeof(T).FullName;
            ScenarioContext.Current[key] = value;
            return value;
        }

        public static void SaveValue<T>(T value, string key)
        {
            if (ScenarioContext.Current == null)
            {
                return;
            }

            ScenarioContext.Current[key] = value;
        }
    }
}
