using OpenQA.Selenium;

namespace WebhookInspectorTests.PageObjects
{
    public class LoginPage : BasePage
    {
        private By EmailInput => By.CssSelector("input[type='email']");
        private By PasswordInput => By.CssSelector("input[type='password']");
        private By LoginButton => By.XPath("//button[text()='Login']");
        private By LoginHeading => By.XPath("//h2[text()='Login']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void GoToLoginPage()
        {
            NavigateTo(Config.TestSettings.BaseUrl);
        }

        public void EnterEmail(string email)
        {
            var emailField = WaitForElement(EmailInput);
            emailField.Clear();
            emailField.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            var passwordField = WaitForElement(PasswordInput);
            passwordField.Clear();
            passwordField.SendKeys(password);
        }

        public void ClickLogin()
        {
            var loginBtn = WaitForElement(LoginButton);
            loginBtn.Click();
        }

        public void Login(string email, string password)
        {
            EnterEmail(email);
            EnterPassword(password);
            ClickLogin();
        }

        public bool IsLoginPageDisplayed()
        {
            return IsElementPresent(LoginHeading);
        }

    }
}