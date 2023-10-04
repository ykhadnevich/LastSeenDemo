// See https://aka.ms/new-console-template for more information

using LastSeenDemo;

var application = new LastSeenApplication(new Loader());
var result = application.Show(DateTimeOffset.Now);

foreach(var item in result)
  Console.WriteLine(item);
