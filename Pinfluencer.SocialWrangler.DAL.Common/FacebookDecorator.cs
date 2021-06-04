using Facebook;
using Newtonsoft.Json;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Clients;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Factories;
using Pinfluencer.SocialWrangler.DAL.Common.Dtos;

namespace Pinfluencer.SocialWrangler.DAL.Common
{
    //TODO: GRAPH API VERSIONING
    public class FacebookDecorator : IFacebookDecorator
    {
        private IFacebookClientAdapter _facebookClient;
        private readonly IFacebookClientFactory _facebookClientFactory;
        private readonly ISerializer _serializer;

        public FacebookDecorator( IFacebookClientFactory facebookClientFactory, ISerializer serializer )
        {
            _facebookClientFactory = facebookClientFactory;
            _serializer = serializer;
        }

        public string Token { set => _facebookClient = _facebookClientFactory.Factory( value ); }
        
        public string Get( string url, string fields ) =>
            _serializer.Serialize( _facebookClient.Get( url, new RequestFields { fields = fields } ) );

        public string Get<T>( string url, T parameters ) =>
            _serializer.Serialize( _facebookClient.Get( url, parameters ) );

        public T Get<T>( string url, string fields ) =>
            _serializer.Deserialize<T>( Get( url, fields ) );

        public TReturn Get<TReturn>( string url, object parameters ) =>
            _serializer.Deserialize<TReturn>( Get( url, parameters ) );
    }
}