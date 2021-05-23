using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Repositories;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Crosscutting.CodeContracts;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Common.Dtos;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Repositories
{
    public class InstagramUserRepository : FacebookRepository<InstagramUserRepository>, IInsightsSocialUserRepository
    {
        private readonly FacebookDecorator _facebookDecorator;
        private readonly ILoggerAdapter<InstagramUserRepository> _logger;

        public InstagramUserRepository( FacebookDecorator facebookDecorator, ILoggerAdapter<InstagramUserRepository> logger ) : base( logger )
        {
            _facebookDecorator = facebookDecorator;
            _logger = logger;
        }

        public OperationResult<SocialInsightsUser> Get( string id ) { throw new NotImplementedException( ); }

        public OperationResult<IEnumerable<SocialInsightsUser>> GetAll( )
        {
            var ( result, fbResult ) = ValidateFacebookCall( ( ) => _facebookDecorator.Get( "me/accounts",
                "instagram_business_account{id,username,name,biography,followers_count}" ) );
            if( !fbResult )
            {
                _logger.LogError( "instagram users were not fetched" );
                return new OperationResult<IEnumerable<SocialInsightsUser>>( Enumerable.Empty<SocialInsightsUser>( ),
                    OperationResultEnum.Failed );
            }
            var dataArray = JsonConvert.DeserializeObject<DataArray<FacebookPage>>( result );
            new PostCondition( ).Evaluate( dataArray != null );
            var instaAccounts = dataArray?.Data.Select( x => x.Insta ).Where( x => x != null );
            var repositoryResult = new OperationResult<IEnumerable<SocialInsightsUser>>( instaAccounts?.Select( x => new SocialInsightsUser
            {
                Username = x.Username,
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