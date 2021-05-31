﻿using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core.Models.Social;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Repositories
{
    public interface ISocialInfoUserRepository
    {
        OperationResult<SocialInfoUser> Get( );
    }
}