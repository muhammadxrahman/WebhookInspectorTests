using DotNetEnv;

namespace WebhookInspectorTests.Config
{
    public static class TestSettings
    {

        static TestSettings()
        {
            // Load .env from project root
            var projectRoot = Directory.GetCurrentDirectory();
            var envPath = Path.Combine(projectRoot, ".env");
            
            if (File.Exists(envPath))
            {
                Env.Load(envPath);
            }
            else
            {
                // Try going up to find .env (in case we're in bin/Debug/net8.0)
                var parentPath = Path.Combine(projectRoot, "../../../.env");
                if (File.Exists(parentPath))
                {
                    Env.Load(Path.GetFullPath(parentPath));
                }
            }
        }
        public static string BaseUrl => 
            Environment.GetEnvironmentVariable("TEST_BASE_URL") ?? throw new Exception("BASE_URL environment variable not set");// => read only versus =
        public static int DefaultTimeout = 10;
        public static int ImplicitWait = 5;

        // account credentials
        public static string TestEmail => Environment.GetEnvironmentVariable("TEST_EMAIL") 
            ?? throw new Exception("TEST_EMAIL environment variable not set");
        public static string TestPassword => Environment.GetEnvironmentVariable("TEST_PASSWORD") 
            ?? throw new Exception("TEST_PASSWORD environment variable not set");
        public static string TestUsername => Environment.GetEnvironmentVariable("TEST_USERNAME") 
            ?? throw new Exception("TEST_USERNAME environment variable not set");

    }
}