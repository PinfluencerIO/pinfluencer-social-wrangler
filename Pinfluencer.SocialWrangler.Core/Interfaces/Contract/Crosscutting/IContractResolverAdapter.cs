using System;
using Newtonsoft.Json.Serialization;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting
{
    public interface IContractResolverAdapter
    {
        IContractResolver Resolver { get; set; }
        JsonContract ResolveContract( Type type );
    }
}