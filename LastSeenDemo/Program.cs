// See https://aka.ms/new-console-template for more information

using LastSeenDemo;

var userLoader = new UserLoader(new Loader(), "https://sef.podkolzin.consulting/api/users/lastSeen");
var application = new LastSeenApplication(userLoader);
var result = application.Show(DateTimeOffset.Now);

foreach (var item in result)
    Console.WriteLine(item);
