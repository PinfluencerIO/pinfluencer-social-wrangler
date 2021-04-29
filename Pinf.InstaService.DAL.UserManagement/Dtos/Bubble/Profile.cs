using Newtonsoft.Json;

namespace Pinf.InstaService.DAL.UserManagement.Dtos.Bubble
{
    public class Profile
    {
        [ JsonProperty( "_id" ) ] public string Id { get; set; }

        public string Name { get; set; }
    }
}