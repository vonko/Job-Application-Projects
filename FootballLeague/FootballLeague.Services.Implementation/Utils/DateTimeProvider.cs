using FootballLeague.Services.Utils;
using System;

namespace FootballLeague.Services.Implementation.Utils
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrentDateTime()
        {
            return DateTime.UtcNow; 
            /*not to use the local time of the server. An international project can be hosted anywhere in the world,
              so the best practice is to use Utc.Now and on the client side adjust the time to the current time zone*/
        }
    }
}
