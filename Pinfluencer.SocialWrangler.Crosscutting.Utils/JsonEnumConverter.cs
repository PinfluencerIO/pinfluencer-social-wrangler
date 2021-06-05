using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pinfluencer.SocialWrangler.Crosscutting.Utils
{
    [ Obsolete ]
    public class JsonEnumConverter<T> : StringEnumConverter where T : Enum
    {
        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            writer.WriteValue( ( value as Enum )?.ToString( ).ToLower( ) );
        }

        public override object ReadJson( JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer )
        {
            return( reader.Value?.ToString( ) ).Enumify<T>( );
        }
    }
}