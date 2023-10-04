namespace LastSeenDemo;

public class LastSeenApplication
{
  private readonly ILoader _loader;
  public LastSeenApplication(ILoader loader)
  {
    _loader = loader;
  }


  public List<string> Show(DateTimeOffset now)
  {
    var userLoader = new UserLoader(_loader, "https://sef.podkolzin.consulting/api/users/lastSeen");
    var users = userLoader.LoadAllUsers();
    var format = new LastSeenFormatter();

    var result = new List<string>();
    foreach (var u in users)
    {
      result.Add($"{u.Nickname} {format.Format(now, u.LastSeenDate ?? now)}");
    }
    return result;
  }
}