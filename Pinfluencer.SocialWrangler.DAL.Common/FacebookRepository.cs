using System;
using Facebook;
using Pinfluencer.SocialWrangler.Crosscutting.Core.Interfaces.Contract;

namespace Pinfluencer.SocialWrangler.DAL.Common
{
    [ Obsolete ]
    public abstract class FacebookRepository<T> where T : class
    {
        protected readonly ILoggerAdapter<T> Logger;

        protected FacebookRepository( ILoggerAdapter<T> logger ) { Logger = logger; }

        protected( string, bool ) ValidateFacebookCall( Func<string> facebookCall )
        {
            var errorReturn = ( default( string ), false );
            try { return( facebookCall( ), true ); }
            catch( FacebookApiLimitException ) { Logger.LogError( "facebook api limit error occured" ); }
            catch( FacebookOAuthException ) { Logger.LogError( "facebook oauth error occured" ); }
            catch( FacebookApiException e )
            {
                Logger.LogError( "facebook api error occured" );
                Logger.LogError( e.Message );
            }

            return errorReturn;
        }
        
        protected( T, bool ) ValidateFacebookCall<T>( Func<T> facebookCall )
        {
            var errorReturn = ( default( T ), false );
            try { return( facebookCall( ), true ); }
            catch( FacebookApiLimitException ) { Logger.LogError( "facebook api limit error occured" ); }
            catch( FacebookOAuthException ) { Logger.LogError( "facebook oauth error occured" ); }
            catch( FacebookApiException e )
            {
                Logger.LogError( "facebook api error occured" );
                Logger.LogError( e.Message );
            }

            return errorReturn;
        }
    }
}