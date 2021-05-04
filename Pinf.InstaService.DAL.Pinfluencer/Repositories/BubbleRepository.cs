using System;
using System.Net;
using System.Net.Http;
using Pinf.InstaService.Core.Interfaces.Clients;
using Pinf.InstaService.Crosscutting.Utils;

namespace Pinf.InstaService.DAL.Pinfluencer.Repositories
{
    public abstract class BubbleRepository<TRepo> where TRepo : class
    {
        protected readonly IBubbleClient BubbleClient;
        protected readonly ILoggerAdapter<TRepo> Logger;

        protected BubbleRepository( IBubbleClient bubbleClient, ILoggerAdapter<TRepo> logger )
        {
            BubbleClient = bubbleClient;
            Logger = logger;
        }
        
        protected bool ValidateHttpCode( HttpStatusCode code ) { return code.GetHashCode( ).ToString( )[0].ToString() == "2"; }

        protected( bool, T ) ValidateRequestException<T>( Func<T> httpFunc )
        {
            try { return( true, httpFunc( ) ); }
            catch( Exception e ) when( e is ArgumentException || e is HttpRequestException )
            {
                return( false, default );
            }
        }
    }
}