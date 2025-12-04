using OpenQA.Selenium;

namespace WebhookInspectorTests.PageObjects
{
    public class MainPage : BasePage
    {
        // header section
        private By WelcomeMessage => By.XPath("//span[contains(text(), 'Welcome,')]");
        private By LogoutButton => By.CssSelector("button.btn-logout");
        private By ConnectedIndicator => By.CssSelector("span.status-connected");

        // endpoints section
        private By EndpointHeading => By.XPath("//h3[text()='Your Endpoint:']");
        private By EndpointNameInput => By.CssSelector("input[placeholder='Click to add a name or description...']");
        private By EndpointUrlCode => By.CssSelector("div.endpoint-url code");
        private By CopyButton => By.CssSelector("button.btn-copy");
        private By GenerateNewButton => By.CssSelector("button.btn-secondary");

        // rules section
        private By ValidationRulesHeading => By.XPath("//h3[text()='Validation Rules (Optional):']");
        private By RuleTypeDropdown => By.CssSelector("select.rule-type-select");
        private By RuleFieldInput => By.CssSelector("input.rule-field-input");
        private By AddRuleButton => By.CssSelector("button.btn-add-rule");
        private By NoRulesMessage => By.CssSelector("p.no-rules-message");

        // test section
        private By QuickTestHeading => By.XPath("//h3[text()='Quick Test:']");
        private By SendTestWebhookButton => By.CssSelector("button.btn-test");

        // live webhooks section
        private By LiveWebhooksHeading => By.XPath("//h3[contains(text(), 'Live Webhooks')]");
        private By WaitingMessage => By.CssSelector("p.waiting");
        private By SaveWebhookButton => By.CssSelector("button.btn-save");

        // saved webhooks section
        private By SavedWebhooksHeading => By.XPath("//h3[contains(text(), 'Saved Webhooks')]");
        private By DeleteWebhookButton => By.CssSelector("button.btn-delete");


        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        // verification methods

        public bool IsLoggedIn()
        {
            return IsElementPresent(WelcomeMessage);
        }

        public string GetWelcomeMessage()
        {
            var element = WaitForElement(WelcomeMessage);
            return element.Text;
        }

        public bool IsConnected()
        {
            return IsElementPresent(ConnectedIndicator);
        }

        public bool IsEndpointDisplayed()
        {
            return IsElementPresent(EndpointHeading);
        }

        // header methods

        public void ClickLogout()
        {
            var logoutBtn = WaitForElement(LogoutButton);
            logoutBtn.Click();
        }

        // endpoint methods
        public string GetEndpointUrl()
        {
            var codeElement = WaitForElement(EndpointUrlCode);
            return codeElement.Text;
        }

        public void EnterEndpointName(string name)
        {
            var nameInput = WaitForElement(EndpointNameInput);
            nameInput.Clear();
            nameInput.SendKeys(name);
        }

        public void ClickCopy()
        {
            var copyBtn = WaitForElement(CopyButton);
            copyBtn.Click();
        }

        public void ClickGenerateNew()
        {
            var generateNewBtn = WaitForElement(GenerateNewButton);
            generateNewBtn.Click();
        }

        // rules methods
        // pass

        // test methods
        public void ClickSendTestWebhook()
        {
            var sendBtn = WaitForElement(SendTestWebhookButton);
            sendBtn.Click();
        }

        // live webhooks methods
        public bool IsWaitingForWebhooks()
        {
            return IsElementPresent(WaitingMessage);
        }

        public void ClickSaveWebhook()
        {
            var saveBtn = WaitForElement(SaveWebhookButton);
            saveBtn.Click();
        }

        // saved webhooks methods
        public void ClickDeleteWebhook()
        {
            var deleteBtn = WaitForElement(DeleteWebhookButton);
            deleteBtn.Click();
        }

        public bool HasSavedWebhooks()
        {
            return IsElementPresent(SavedWebhooksHeading);
        }

    }
}