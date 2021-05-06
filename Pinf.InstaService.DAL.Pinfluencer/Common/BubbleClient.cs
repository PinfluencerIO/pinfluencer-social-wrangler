using System;
using Pinf.InstaService.Crosscutting.Web;
using Pinf.InstaService.DAL.Core.Interfaces.Clients;

namespace Pinf.InstaService.DAL.Pinfluencer.Common
{
    public class BubbleClient : ApiClient, IBubbleClient
    {
        public BubbleClient( IHttpClient httpClient ) : base( httpClient ) { }

        public BubbleClient( IHttpClient httpClient, Uri uri, string token ) : base( httpClient, uri, token ) { }
    }
}