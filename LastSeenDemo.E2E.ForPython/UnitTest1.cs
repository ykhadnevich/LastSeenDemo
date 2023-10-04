namespace LastSeenDemo.E2E.ForPython;

public class UnitTest1
{
  [Fact]
  public void Test1()
  {
    using var client = new HttpClient();
    using var result = client.Send(new HttpRequestMessage(HttpMethod.Get, "http://127.0.0.1:8000/formated"));
    using var reader = new StreamReader(result.Content.ReadAsStream());
    var stringContent = reader.ReadToEnd();
    
    Assert.True(result.IsSuccessStatusCode);
    Assert.NotEmpty(stringContent);
  }
}
