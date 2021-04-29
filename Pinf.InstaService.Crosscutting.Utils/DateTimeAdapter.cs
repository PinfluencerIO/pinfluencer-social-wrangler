using System;

namespace Pinf.InstaService.Crosscutting.Utils
{
    public class DateTimeAdapter : IDateTimeAdapter
    {
        public DateTime Now( ) => DateTime.Now;
    }
}