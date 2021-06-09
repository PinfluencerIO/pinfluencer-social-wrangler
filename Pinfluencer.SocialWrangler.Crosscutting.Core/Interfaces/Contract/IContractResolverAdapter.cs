using System;
using Newtonsoft.Json.Serialization;

namespace Pinfluencer.SocialWrangler.Crosscutting.Core.Interfaces.Contract
{
    public interface IContractResolverAdapter
    {
        IContractResolver Resolver { get; set; }
        JsonContract ResolveContract( Type type );
    }
}