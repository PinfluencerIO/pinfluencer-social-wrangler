using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Utilities;

namespace Pinf.InstaService.Crosscutting.Utils
{
    public class JsonEnumConverter<T> : StringEnumConverter where T : Enum
    {
        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer ) =>
            writer.WriteValue( ( value as Enum )?.ToString( ).ToLower( ) );

        public override object ReadJson( JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer ) => ( reader.Value?.ToString( ) ).Enumify<T>( );
    }
}