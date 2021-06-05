using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Clients;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Factories;
using Pinfluencer.SocialWrangler.DAL.Common.Dtos;

namespace Pinfluencer.SocialWrangler.DAL.Common
{
    //TODO: GRAPH API VERSIONING
    public class FacebookDecorator : IFacebookDecorator
    {
        private readonly IFacebookClientFactory _facebookClientFactory;
        private readonly ISerializer _serializer;
        private IFacebookClientAdapter _facebookClient;

        public FacebookDecorator( string token, IFacebookClientFactory facebookClientFactory, ISerializer serializer )
        {
            _facebookClientFactory = facebookClientFactory;
            _serializer = serializer;
            _facebookClient = _facebookClientFactory.Factory( token );
        }

        public string Get( string url, string fields )
        {
            return _serializer.Serialize( _facebookClient.Get( url, new RequestFields { fields = fields } ) );
        }

        public string Get<T>( string url, T parameters )
        {
            return _serializer.Serialize( _facebookClient.Get( url, parameters ) );
        }

        public T Get<T>( string url, string fields ) { return _serializer.Deserialize<T>( Get( url, fields ) ); }

        public TReturn Get<TReturn>( string url, object parameters )
        {
            return _serializer.Deserialize<TReturn>( Get( url, parameters ) );
        }
    }
}