using Xunit;
using WebhookInspectorTests.PageObjects;
using WebhookInspectorTests.Config;

namespace WebhookInspectorTests.Tests
{
    public class LoginTests : BaseTest
    {
        [Fact]
        public void LoginPage_ShouldLoad_Successfully()
        {
            // Arrange
            var loginPage = new LoginPage(Driver);

            // Act
            loginPage.GoToLoginPage();

            // Assert
            Assert.True(loginPage.IsLoginPageDisplayed(), "Login page should be displayed");
            Assert.Contains("Webhook Inspector", loginPage.GetPageTitle());
        }

        [Fact]
        public void SuccessfulLogin_ShouldNavigate_ToMainPage()
        {
            // Arrange
            var loginPage = new LoginPage(Driver);
            var mainPage = new MainPage(Driver);

            // Act
            loginPage.GoToLoginPage();
            loginPage.Login(TestSettings.TestEmail, TestSettings.TestPassword);

            // Wait for navigation (we'll improve this later)
            System.Threading.Thread.Sleep(2000);

            // Assert
            Assert.True(mainPage.IsLoggedIn(), "User should be logged in");
            Assert.Contains("Welcome", mainPage.GetWelcomeMessage());
        }

        [Fact]
        public void SuccessfulLogin_ShouldDisplay_ConnectedIndicator()
        {
            // Arrange
            var loginPage = new LoginPage(Driver);
            var mainPage = new MainPage(Driver);

            // Act
            loginPage.GoToLoginPage();
            loginPage.Login(TestSettings.TestEmail, TestSettings.TestPassword);
            System.Threading.Thread.Sleep(2000);

            // Assert
            Assert.True(mainPage.IsConnected(), "Connected indicator should be displayed");
        }

        [Fact]
        public void SuccessfulLogin_ShouldDisplay_EndpointUrl()
        {
            // Arrange
            var loginPage = new LoginPage(Driver);
            var mainPage = new MainPage(Driver);

            // Act
            loginPage.GoToLoginPage();
            loginPage.Login(TestSettings.TestEmail, TestSettings.TestPassword);
            System.Threading.Thread.Sleep(2000);

            // Assert
            Assert.True(mainPage.IsEndpointDisplayed(), "Endpoint should be displayed");
            
            string endpointUrl = mainPage.GetEndpointUrl();
            Assert.NotEmpty(endpointUrl);
            Assert.Contains("railway.app/catch", endpointUrl);
        }

        [Fact]
        public void Logout_ShouldReturn_ToLoginPage()
        {
            // Arrange
            var loginPage = new LoginPage(Driver);
            var mainPage = new MainPage(Driver);

            // Act
            loginPage.GoToLoginPage();
            loginPage.Login(TestSettings.TestEmail, TestSettings.TestPassword);
            System.Threading.Thread.Sleep(2000);
            
            mainPage.ClickLogout();
            System.Threading.Thread.Sleep(1000);

            // Assert
            Assert.True(loginPage.IsLoginPageDisplayed(), "Should return to login page after logout");
        }

    }
}