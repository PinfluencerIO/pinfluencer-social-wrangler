using System.Collections.Generic;

namespace BLL.Models.InstaUser
{
    public class InstaUserIdentityCollection
    {
        public IEnumerable<InstaUserIdentity> InstaUserIdentities { get; }

        public bool HasMultiple { get; }

        public bool IsEmpty { get; }

        public InstaUserIdentityCollection(IEnumerable<InstaUserIdentity> instaUserIdentities, bool hasMultiple, bool isEmpty)
        {
            InstaUserIdentities = instaUserIdentities;
            HasMultiple = hasMultiple;
            IsEmpty = isEmpty;
        }
    }
}