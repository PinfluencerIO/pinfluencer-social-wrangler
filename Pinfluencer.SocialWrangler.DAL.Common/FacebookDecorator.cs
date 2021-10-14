using Aidan.Common.Core.Interfaces.Contract;
using Pinfluencer.SocialWrangler.DAL.Common.Dtos;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Clients;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Factories;

namespace Pinfluencer.SocialWrangler.DAL.Common
{
    //TODO: GRAPH API VERSIONING
    public class FacebookDecorator : IFacebookDecorator
    {
        private readonly IFacebookClientFactory _facebookClientFactory;
        private readonly ISerializer _serializer;
        private IFacebookClientAdapter _facebookClient;

        public string Token
        {
            set => _facebookClient = _facebookClientFactory.Factory( value );
        }
        
        public FacebookDecorator( IFacebookClientFactory facebookClientFactory, ISerializer serializer )
        {
            _facebookClientFactory = facebookClientFactory;
            _serializer = serializer;
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