using System;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;

namespace Pinfluencer.SocialWrangler.Crosscutting.Utils
{
    public class DateTimeAdapter : IDateTimeAdapter
    {
        public DateTime Now( ) => DateTime.Now;
    }
}