namespace LastSeenDemo.E2E;

public static class Configuration
{
    private const string DefaultUrl = "http://127.0.0.1:5079";
    
    public static string
      BaseUrl => Environment.GetEnvironmentVariable("VM_IP") ?? DefaultUrl;
}
