﻿using System.Collections.Generic;
using Pinf.InstaService.Core.Models.InstaUser;

namespace Pinf.InstaService.Core.Interfaces.Repositories
{
    public interface ISocialUserRepository
    {
        OperationResult<InstaUser> Get( string id );

        OperationResult<IEnumerable<InstaUser>> GetAll( );
    }
}