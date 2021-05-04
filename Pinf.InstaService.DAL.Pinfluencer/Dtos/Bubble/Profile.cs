using Newtonsoft.Json;

namespace Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble
{
    public class Profile
    {
        [ JsonProperty( "_id" ) ] public string Id { get; set; }

        public string Name { get; set; }
    }
}