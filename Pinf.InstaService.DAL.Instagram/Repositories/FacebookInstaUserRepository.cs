using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.BLL.Models.InstaUser;
using Pinf.InstaService.Crosscutting.CodeContracts;
using Pinf.InstaService.DAL.Instagram.Dtos;
using InstaUser = Pinf.InstaService.BLL.Models.InstaUser.InstaUser;

namespace Pinf.InstaService.DAL.Instagram.Repositories
{
    public class FacebookInstaUserRepository : IInstaUserRepository
    {
        private readonly FacebookContext _facebookContext;

        public FacebookInstaUserRepository( FacebookContext facebookContext ) { _facebookContext = facebookContext; }

        public OperationResult<InstaUser> GetUser( string id ) { throw new NotImplementedException( ); }

        public OperationResult<IEnumerable<InstaUser>> GetUsers( )
        {
            try
            {
                var result = _facebookContext.Get( "me/accounts",
                    "instagram_business_account{id,username,name,biography,followers_count}" );
                var dataArray = JsonConvert.DeserializeObject<DataArray<FacebookPage>>( result );

                new PostCondition( ).Evaluate( dataArray != null );

                var instaAccounts = dataArray.Data.Select( x => x.Insta ).Where( x => x != null );
                return new OperationResult<IEnumerable<InstaUser>>( instaAccounts.Select( x => new InstaUser(
                    new InstaUserIdentity( x.Username, x.Id ), x.Name, x.Bio, x.Followers
                ) ), OperationResultEnum.Success );
            }
            catch( Exception )
            {
                return new OperationResult<IEnumerable<InstaUser>>( Enumerable.Empty<InstaUser>( ),
                    OperationResultEnum.Failed );
            }
        }
    }
}