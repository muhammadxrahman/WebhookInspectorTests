using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebhookInspectorTests.Helpers
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();

            options.AddArgument("--headless"); // don't open and show browser
            options.AddArgument("--no-sandbox"); // security setting needed in some environments
            options.AddArgument("--disable-dev-shm-usage"); // prevents memory issues in docker/CI envs
            options.AddArgument("--disable-gpu");
            options.AddArgument("--window-size=1920,1080");

            var driver = new ChromeDriver(options);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Config.TestSettings.ImplicitWait);

            return driver;
        }
    }

}