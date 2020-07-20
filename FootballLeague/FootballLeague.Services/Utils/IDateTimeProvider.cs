using System;

namespace FootballLeague.Services.Utils
{
    public interface IDateTimeProvider
    {
        DateTime GetCurrentDateTime();
    }
}
