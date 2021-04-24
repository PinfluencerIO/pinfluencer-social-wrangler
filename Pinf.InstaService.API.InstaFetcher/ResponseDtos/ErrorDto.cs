using System.Text.Json.Serialization;

namespace Pinf.InstaService.API.InstaFetcher.ResponseDtos
{
    public class ErrorDto
    {
        [ JsonPropertyName( "error_msg" ) ] public string ErrorMsg { get; set; }
    }
}