using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Pinf.InstaService.Crosscutting.Utils;

namespace Pinf.InstaService.Core.Enum
{
    //TODO => MAKE DYNAMIC ( REFLECTION )
    [ JsonConverter( typeof( StringEnumConverter ) ) ]
    public enum GenderEnum
    {
        Male,
        Female
    }
}