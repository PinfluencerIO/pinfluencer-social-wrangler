using Newtonsoft.Json;

namespace Pinfluencer.SocialWrangler.Bootstrapping.DevOps.Deploy
{
    public class AppsettingsDto
    {
        public AuthServiceSettingsDto AuthService { get; set; }

        public PinfluencerDataSettingsDto PinfluencerData { get; set; }

        [ JsonProperty( PropertyName = "Simple-Auth-Key" ) ]
        public string SimpleAuthKey { get; set; }
    }
}