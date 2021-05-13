using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Repositories;
using Pinfluencer.SocialWrangler.Crosscutting.CodeContracts;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Common.Dtos;
using Pinfluencer.SocialWrangler.DAL.Instagram.Dtos;
using InstaUser = Pinfluencer.SocialWrangler.Core.Models.InstaUser.InstaUser;

namespace Pinfluencer.SocialWrangler.DAL.Instagram.Repositories
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