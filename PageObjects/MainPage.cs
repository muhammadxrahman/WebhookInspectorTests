using OpenQA.Selenium;

namespace WebhookInspectorTests.PageObjects
{
    public class MainPage : BasePage
    {
        // header section
        private By WelcomeMessage => By.XPath("//span[contains(text(), 'Welcome,')]");
        private By LogoutButton => By.CssSelector("button.btn-logout");
        private By ConnectedIndicator => By.XPath("//div[text()='Connected']");

        // endpoints section
        private By EndpointHeading => By.XPath("//h3[text()='Your Endpoint:']");
        private By EndpointNameInput => By.CssSelector("input[placeholder='Click to add a name or description...']");
        private By EndpointUrlCode => By.CssSelector("div.endpoint-url code");
        private By CopyButton => By.CssSelector("button.btn-copy");
        private By GenerateNewButton => By.CssSelector("button.btn-secondary");

        // rules section


        // test section


        // live webhooks section


        // saved webhooks section





        public MainPage(IWebDriver driver) : base(driver)
        {
        }


    }
}