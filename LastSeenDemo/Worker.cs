namespace LastSeenDemo;

public class UserTimeSpan
{
  public DateTimeOffset Login { get; set; }
  public DateTimeOffset? Logout { get; set; }
}

public class Worker
{
  private readonly UserLoader _loader;
  private readonly AllUsersTransformer _transformer;
  private readonly List<Guid> _forgottenUsers = new();
  
  public Worker(UserLoader loader, AllUsersTransformer transformer)
  {
    _loader = loader;
    _transformer = transformer;
    Users = new Dictionary<Guid, List<UserTimeSpan>>();
  }
  
  public Dictionary<Guid, List<UserTimeSpan>> Users { get; }
  
  public void LoadDataPeriodically()
  {
    List<Guid> onlineUsers = new();
    
    while (true)
    {
      Console.WriteLine("Loading data");
      var allUsers = _loader.LoadAllUsers();
      _transformer.Transform(allUsers, onlineUsers, Users);
      Console.WriteLine("Data loaded");
      Thread.Sleep(5000);
    }
  }
  public void Forget(Guid userId)
  {
    _forgottenUsers.Add(userId);
    Users.Remove(userId);
  }
}