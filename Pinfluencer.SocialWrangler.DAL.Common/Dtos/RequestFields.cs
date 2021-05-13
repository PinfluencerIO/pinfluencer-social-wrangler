using System.Runtime.Serialization;

namespace Pinfluencer.SocialWrangler.DAL.Common.Dtos
{
    [ DataContract ]
    public class RequestFields
    {
        [ DataMember( Name = "fields" ) ]
        public string fields { get; set; }
    }
}