using System.Text.Json.Serialization;

namespace Pinf.InstaService.API.InstaFetcher.ResponseDtos
{
    public class SuccessDto
    {
        [ JsonPropertyName( "msg" ) ] public string Msg { get; set; }
    }
}