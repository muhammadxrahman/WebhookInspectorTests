using OpenQA.Selenium;
using WebhookInspectorTests.Helpers;

namespace WebhookInspectorTests.Tests
{
    public class BaseTest : IDisposable
    {
        protected IWebDriver Driver;

        public BaseTest()
        {
            Driver = WebDriverFactory.CreateChromeDriver();
        }

        public void Dispose()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }
    }
}