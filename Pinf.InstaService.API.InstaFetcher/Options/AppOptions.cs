using System;

namespace Pinf.InstaService.API.InstaFetcher.Options
{
    public class AppOptions : IDisposable
    {
        public Auth0Options Auth0 { get; set; }
        public void Dispose( ) { throw new NotImplementedException( ); }
    }
}