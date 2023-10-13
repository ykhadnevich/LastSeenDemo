using LastSeenDemo;

public class OnlineDetector
{
  public bool Detect(List<UserTimeSpan> data, DateTimeOffset date)
  {
    foreach (var interval in data)
    {
      if (interval.Login <= date && (interval.Logout == null || interval.Logout >= date))
      {
        return true;
      }
    }
    return false;
  }
}