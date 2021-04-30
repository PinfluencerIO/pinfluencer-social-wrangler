using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Pinf.InstaService.DAL.Common.Dtos
{
    [ DataContract ]
    public class RequestFields
    {
        [ DataMember( Name = "fields" ) ]
        public string fields { get; set; }
    }
}