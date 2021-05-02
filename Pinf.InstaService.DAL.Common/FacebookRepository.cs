using System;
using Facebook;
using Pinf.InstaService.Crosscutting.Utils;

namespace Pinf.InstaService.DAL.Common
{
    public abstract class FacebookRepository
    {
        protected readonly ILoggerAdapter<FacebookRepository> Logger;

        protected FacebookRepository( ILoggerAdapter<FacebookRepository> logger ) { Logger = logger; }
        
        protected( string, bool ) ValidateFacebookCall( Func<string> facebookCall )
        {
            var errorReturn = ( default( string ), false );
            try { return( facebookCall( ), true ); }
            catch( FacebookApiLimitException )
            {
                Logger.LogError( "facebook api limit error occured" );
            }
            catch( FacebookOAuthException )
            {
                Logger.LogError( "facebook oauth error occured" );
            }
            catch( FacebookApiException e )
            {
                Logger.LogError( "facebook api error occured" );
                Logger.LogError( e.Message );
            }
            return errorReturn;;
        }
    }
}