using LastSeenDemo;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/formatted", () =>
{
  var application = new LastSeenApplication(new Loader());
  var result = application.Show(DateTimeOffset.Now);
  return result;
});

var worker = new Worker(
    new UserLoader(new Loader(), "https://sef.podkolzin.consulting/api/users/lastSeen"), 
    new AllUsersTransformer(new UserTransformer(new DateTimeProvider())));

Task.Run(worker.LoadDataPeriodically);

app.MapGet("/api/stats/users/", (DateTimeOffset date) =>
{
  var detector = new OnlineDetector();
  // int usersOnline = 0;
  // foreach (var (_, user) in users)
  // {
  //   if (detector.Detect(user, date))
  //   {
  //     usersOnline++;
  //   }
  // }
  // return new { usersOnline };
  return new { usersOnline = worker.Users.Values.Count(u => detector.Detect(u, date)) };
});

app.Run();