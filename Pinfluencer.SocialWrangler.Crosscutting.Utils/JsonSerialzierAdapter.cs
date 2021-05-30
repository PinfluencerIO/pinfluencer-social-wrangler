using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pinfluencer.SocialWrangler.Crosscutting.Utils
{
    public class JsonSerialzierAdapter : ISerializer
    {
        private readonly IContractResolver _contractResolver;
        private readonly JsonSerializerSettings _settings;

        public JsonSerialzierAdapter( IContractResolver contractResolver )
        {
            _contractResolver = contractResolver;
            _settings = new JsonSerializerSettings { ContractResolver = contractResolver };
        }

        public string Serialize( object content ) => JsonConvert.SerializeObject( content, _settings );

        public T Deserialize<T>( string content ) => JsonConvert.DeserializeObject<T>( content, _settings );
    }
}