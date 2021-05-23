using Facebook;
using Newtonsoft.Json;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.DAL.Common.Dtos;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Clients;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Factories;

namespace Pinfluencer.SocialWrangler.DAL.Common
{
    //TODO: GRAPH API VERSIONING
    public class FacebookDecorator : IFacebookDecorator
    {
        private IFacebookClientAdapter _facebookClient;
        private readonly IFacebookClientFactory _facebookClientFactory;
        
        public FacebookDecorator( IFacebookClientFactory facebookClientFactory )
        {
            _facebookClientFactory = facebookClientFactory;
        }

        public string Token { set => _facebookClient = _facebookClientFactory.Get( value ); }
        
        public string Get( string url, string fields ) =>
            JsonConvert.SerializeObject( _facebookClient.Get( url, new RequestFields { fields = fields } ) );

        public string Get<T>( string url, T parameters ) =>
            JsonConvert.SerializeObject( _facebookClient.Get( url, parameters ) );

        public T Get<T>( string url, string fields ) =>
            JsonConvert.DeserializeObject<T>( Get( url, fields ) );

        public TReturn Get<TReturn>( string url, object parameters ) =>
            JsonConvert.DeserializeObject<TReturn>( Get( url, parameters ) );
    }
}