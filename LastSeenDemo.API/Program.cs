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

app.Run();