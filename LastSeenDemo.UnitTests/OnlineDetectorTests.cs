namespace LastSeenDemo.UnitTests;

using System;
using System.Collections.Generic;
using Xunit;

public class OnlineDetectorTests
{
    private readonly OnlineDetector onlineDetector = new();

    [Fact]
    public void When_UserIsOnline_Should_ReturnTrue()
    {
        // Arrange
        var data = new List<UserTimeSpan>
        {
            new () { Login = DateTimeOffset.Parse("2022-01-01 10:00:00"), Logout = DateTimeOffset.Parse("2022-01-01 12:00:00") },
            new () { Login = DateTimeOffset.Parse("2022-01-01 14:00:00"), Logout = null },
            new () { Login = DateTimeOffset.Parse("2022-01-01 16:00:00"), Logout = DateTimeOffset.Parse("2022-01-01 18:00:00") }
        };
        var date = DateTimeOffset.Parse("2022-01-01 15:00:00");

        // Act
        var result = onlineDetector.Detect(data, date);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void When_UserIsOffline_Should_ReturnFalse()
    {
        // Arrange
        var data = new List<UserTimeSpan>
        {
            new () { Login = DateTimeOffset.Parse("2022-01-01 10:00:00"), Logout = DateTimeOffset.Parse("2022-01-01 12:00:00") },
            new () { Login = DateTimeOffset.Parse("2022-01-01 14:00:00"), Logout = DateTimeOffset.Parse("2022-01-01 16:00:00") },
            new () { Login = DateTimeOffset.Parse("2022-01-01 18:00:00"), Logout = DateTimeOffset.Parse("2022-01-01 20:00:00") }
        };
        var date = DateTimeOffset.Parse("2022-01-01 13:00:00");

        // Act
        var result = onlineDetector.Detect(data, date);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void When_NoDataProvided_Should_ReturnFalse()
    {
        // Arrange
        var data = new List<UserTimeSpan>();
        var date = DateTimeOffset.Parse("2022-01-01 15:00:00");

        // Act
        var result = onlineDetector.Detect(data, date);

        // Assert
        Assert.False(result);
    }
}