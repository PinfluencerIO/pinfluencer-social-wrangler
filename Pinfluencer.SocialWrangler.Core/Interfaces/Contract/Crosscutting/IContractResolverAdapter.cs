using System;
using Newtonsoft.Json.Serialization;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting
{
    public interface IContractResolverAdapter
    {
        JsonContract ResolveContract( Type type );

        IContractResolver Resolver { get; set; }
    }
}