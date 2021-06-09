using System;
using Pinfluencer.SocialWrangler.Crosscutting.Core.Interfaces.Contract;

namespace Pinfluencer.SocialWrangler.Crosscutting.Utils
{
    public class DateTimeAdapter : IDateTimeAdapter
    {
        public DateTime Now( ) { return DateTime.Now; }
    }
}