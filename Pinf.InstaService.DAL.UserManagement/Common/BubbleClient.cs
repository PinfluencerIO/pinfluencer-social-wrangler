using System;
using Pinf.InstaService.Crosscutting.Web;

namespace Pinf.InstaService.DAL.UserManagement.Common
{
    public class BubbleClient : ApiClient
    {
        public BubbleClient( IHttpClient httpClient ) : base( httpClient ) { }

        public BubbleClient( IHttpClient httpClient, Uri uri, string token ) : base( httpClient, uri, token ) { }
    }
}