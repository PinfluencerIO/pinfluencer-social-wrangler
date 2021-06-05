using Newtonsoft.Json;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;

namespace Pinfluencer.SocialWrangler.Crosscutting.Utils
{
    public class JsonSerialzierAdapter : ISerializer
    {
        private readonly IContractResolverAdapter _contractResolver;
        private readonly JsonSerializerSettings _settings;

        public JsonSerialzierAdapter( IContractResolverAdapter contractResolver )
        {
            _contractResolver = contractResolver;
            _settings = new JsonSerializerSettings { ContractResolver = contractResolver.Resolver };
        }

        public string Serialize( object content ) { return JsonConvert.SerializeObject( content, _settings ); }

        public T Deserialize<T>( string content ) { return JsonConvert.DeserializeObject<T>( content, _settings ); }
    }
}