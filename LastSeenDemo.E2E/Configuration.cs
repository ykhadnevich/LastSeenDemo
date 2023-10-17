namespace LastSeenDemo.E2E;

public static class Configuration
{
    private const string DefaultUrl = "http://127.0.0.1:5079";

    public static string BaseUrl
    {
        get
        {
            var env = Environment.GetEnvironmentVariable("VM_IP");
            if (env != null)
            {
                return $"http://{env}";
            }
            return DefaultUrl;
        }
    }
}
