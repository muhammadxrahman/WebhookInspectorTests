namespace WebhookInspectorTests.Config
{
    public static class TestSettings
    {
        public static string BaseUrl = "https://webhook-inspector-nine.vercel.app"; // => read only versus =
        public static int DefaultTimeout = 10;
        public static int ImplicitWait = 5;

        // account credentials
        public static string TestEmail => "testuser@example.com";
        public static string TestPassword => "testpassword123";
        public static string TestUsername => "testaccount";

    }
}