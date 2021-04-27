using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pinf.InstaService.Core.Models.InstaUser
{
    public class InstaUserIdentityCollection
    {
        public InstaUserIdentityCollection( IEnumerable<InstaUserIdentity> instaUserIdentities, bool hasMultiple,
            bool isEmpty )
        {
            InstaUserIdentities = instaUserIdentities;
            HasMultiple = hasMultiple;
            IsEmpty = isEmpty;
        }

        [ JsonPropertyName( "insta_users" ) ] public IEnumerable<InstaUserIdentity> InstaUserIdentities { get; }

        [ JsonPropertyName( "has_multiple" ) ] public bool HasMultiple { get; }

        [ JsonPropertyName( "is_empty" ) ] public bool IsEmpty { get; }
    }
}