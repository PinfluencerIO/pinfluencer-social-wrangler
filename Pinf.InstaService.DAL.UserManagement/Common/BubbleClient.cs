using System;
using Pinf.InstaService.Core.Interfaces.Clients;
using Pinf.InstaService.Crosscutting.Web;

namespace Pinf.InstaService.DAL.UserManagement.Common
{
    public class BubbleClient : ApiClient, IBubbleClient
    {
        public BubbleClient( IHttpClient httpClient ) : base( httpClient ) { }

        public BubbleClient( IHttpClient httpClient, Uri uri, string token ) : base( httpClient, uri, token ) { }
    }
}