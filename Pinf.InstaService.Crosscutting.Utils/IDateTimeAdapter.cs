using System;

namespace Pinf.InstaService.Crosscutting.Utils
{
    public interface IDateTimeAdapter
    {
        DateTime Now( );
    }
}