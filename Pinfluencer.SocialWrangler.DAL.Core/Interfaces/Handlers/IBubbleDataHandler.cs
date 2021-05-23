using System;
using System.Net;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers
{
    public interface IBubbleDataHandler<T> : ICreateable, IReadable, IUpdatable
    {
    }
}