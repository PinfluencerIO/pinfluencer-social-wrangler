using System;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Clients;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.Crosscutting.Web;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Common
{
    public class BubbleClient : ApiClientBase, IBubbleClient
    {
        public BubbleClient( string uri, string token, ISerializer serializer, IHttpClient httpClient ) :
            base( new Uri( uri ), token, serializer, httpClient ) { }
    }
}