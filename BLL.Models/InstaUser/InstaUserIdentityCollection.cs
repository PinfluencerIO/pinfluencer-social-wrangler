using System.Collections.Generic;
using Newtonsoft.Json;

namespace BLL.Models.InstaUser
{
    public class InstaUserIdentityCollection
    {
        [JsonProperty("insta_users")]
        public IEnumerable<InstaUserIdentity> InstaUserIdentities { get; }

        [JsonProperty("has_multiple")]
        public bool HasMultiple { get; }

        [JsonProperty("is_empty")]
        public bool IsEmpty { get; }

        public InstaUserIdentityCollection(IEnumerable<InstaUserIdentity> instaUserIdentities, bool hasMultiple, bool isEmpty)
        {
            InstaUserIdentities = instaUserIdentities;
            HasMultiple = hasMultiple;
            IsEmpty = isEmpty;
        }
    }
}