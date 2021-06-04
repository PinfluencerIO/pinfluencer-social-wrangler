using System;

namespace Pinfluencer.SocialWrangler.Core.Options
{
    public class AppOptions : IDisposable
    {
        public AuthServiceOptions AuthService { get; set; }
        public PinfluencerDataOptions PinfluencerData { get; set; }
        public void Dispose( ) { throw new NotImplementedException( ); }
    }
}