﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.InstaUser;
using Pinf.InstaService.Crosscutting.CodeContracts;
using Pinf.InstaService.DAL.Common;
using Pinf.InstaService.DAL.Common.Dtos;
using Pinf.InstaService.DAL.Instagram.Dtos;
using InstaUser = Pinf.InstaService.Core.Models.InstaUser.InstaUser;

namespace Pinf.InstaService.DAL.Instagram.Repositories
{
    public class InstagramUserRepository : IInstaUserRepository
    {
        private readonly FacebookContext _facebookContext;

        public InstagramUserRepository( FacebookContext facebookContext ) { _facebookContext = facebookContext; }

        public OperationResult<InstaUser> Get( string id ) { throw new NotImplementedException( ); }

        public OperationResult<IEnumerable<InstaUser>> GetAll( )
        {
            try
            {
                var result = _facebookContext.Get( "me/accounts",
                    "instagram_business_account{id,username,name,biography,followers_count}" );
                var dataArray = JsonConvert.DeserializeObject<DataArray<FacebookPage>>( result );

                new PostCondition( ).Evaluate( dataArray != null );

                var instaAccounts = dataArray?.Data.Select( x => x.Insta ).Where( x => x != null );
                return new OperationResult<IEnumerable<InstaUser>>( instaAccounts?.Select( x => new InstaUser
                {
                    Handle = x.Username,
                    Id = x.Id ,
                    Name = x.Name,
                    Bio = x.Bio,
                    Followers = x.Followers
                } ), OperationResultEnum.Success );
            }
            catch( Exception )
            {
                return new OperationResult<IEnumerable<InstaUser>>( Enumerable.Empty<InstaUser>( ),
                    OperationResultEnum.Failed );
            }
        }
    }
}