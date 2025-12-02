using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebhookInspectorTests.PageObjects
{
    public class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.TestSettings.DefaultTimeout));
        }

        protected void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        protected IWebElement WaitForElement(By locator)
        {
            return Wait.Until(driver => 
            {
                var element = driver.FindElement(locator);
                return element.Displayed ? element : null;
            });
        }

        protected bool IsElementPresent(By locator)
        {
            try
            {
                Driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public string GetPageTitle()
        {
            return Driver.Title;
        }

    }
}