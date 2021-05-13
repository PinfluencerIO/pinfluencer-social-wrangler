using System;

namespace Pinfluencer.SocialWrangler.Crosscutting.Utils
{
    public class DateTimeAdapter : IDateTimeAdapter
    {
        public DateTime Now( ) => DateTime.Now;
    }
}