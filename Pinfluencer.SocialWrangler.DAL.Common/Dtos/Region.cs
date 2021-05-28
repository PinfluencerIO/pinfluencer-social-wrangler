﻿using Newtonsoft.Json;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;

namespace Pinfluencer.SocialWrangler.DAL.Common.Dtos
{
    public class Region
    {
        [ JsonProperty("city") ] public string City { get; set; }
        [ JsonProperty("country") ] public string Country { get; set; }
        [ JsonProperty("country_code") ] public CountryEnum CountryCode { get; set; }
    }
}