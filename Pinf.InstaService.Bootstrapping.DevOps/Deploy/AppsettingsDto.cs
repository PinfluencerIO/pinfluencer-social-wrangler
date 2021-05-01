using Newtonsoft.Json;

namespace Pinf.InstaService.Bootstrapping.DevOps.Deploy
{
    public class AppsettingsDto
    {
        public Auth0SettingsDto Auth0 { get; set; }

        public BubbleSettingsDto Bubble { get; set; }

        [ JsonProperty( PropertyName = "Simple-Auth-Key" ) ]
        public string SimpleAuthKey { get; set; }
    }
}