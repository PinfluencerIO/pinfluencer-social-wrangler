using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.InstaUser;
using Pinf.InstaService.Crosscutting.CodeContracts;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.DAL.Common;
using Pinf.InstaService.DAL.Common.Dtos;
using Pinf.InstaService.DAL.Instagram.Dtos;
using InstaUser = Pinf.InstaService.Core.Models.InstaUser.InstaUser;

namespace Pinf.InstaService.DAL.Instagram.Repositories
{
    public class InstagramUserRepository : FacebookRepository<InstagramUserRepository>, ISocialUserRepository
    {
        private readonly FacebookContext _facebookContext;
        private readonly ILoggerAdapter<InstagramUserRepository> _logger;

        public InstagramUserRepository( FacebookContext facebookContext, ILoggerAdapter<InstagramUserRepository> logger ) : base( logger )
        {
            _facebookContext = facebookContext;
            _logger = logger;
        }

        public OperationResult<InstaUser> Get( string id ) { throw new NotImplementedException( ); }

        public OperationResult<IEnumerable<InstaUser>> GetAll( )
        {
            var ( result, fbResult ) = ValidateFacebookCall( ( ) => _facebookContext.Get( "me/accounts",
                "instagram_business_account{id,username,name,biography,followers_count}" ) );
            if( !fbResult )
            {
                _logger.LogError( "instagram users were not fetched" );
                return new OperationResult<IEnumerable<InstaUser>>( Enumerable.Empty<InstaUser>( ),
                    OperationResultEnum.Failed );
            }
            var dataArray = JsonConvert.DeserializeObject<DataArray<FacebookPage>>( result );
            new PostCondition( ).Evaluate( dataArray != null );
            var instaAccounts = dataArray?.Data.Select( x => x.Insta ).Where( x => x != null );
            var repositoryResult = new OperationResult<IEnumerable<InstaUser>>( instaAccounts?.Select( x => new InstaUser
            {
                Handle = x.Username,
                Id = x.Id ,
                Name = x.Name,
                Bio = x.Bio,
                Followers = x.Followers
            } ), OperationResultEnum.Success );
            _logger.LogInfo( "instagram users were fetched" );
            return repositoryResult;
        }
    }
}