using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Models;
using Pinfluencer.SocialWrangler.Core.Interfaces.Repositories;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Crosscutting.CodeContracts;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Common.Dtos;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Repositories
{
    public class InstagramUserRepository :
        IInsightsSocialUserRepository,
        IDataCollectionMappable<IEnumerable<SocialInsightsUser>, DataArray<FacebookPage>>
    {
        private readonly FacebookDecorator _facebookDecorator;
        private readonly IFacebookDataHandler<InstagramUserRepository> _facebookDataHandler;

        public InstagramUserRepository( FacebookDecorator facebookDecorator, IFacebookDataHandler<InstagramUserRepository> facebookDataHandler )
        {
            _facebookDecorator = facebookDecorator;
            _facebookDataHandler = facebookDataHandler;
        }

        public OperationResult<SocialInsightsUser> Get( string id ) { throw new NotImplementedException( ); }

        public OperationResult<IEnumerable<SocialInsightsUser>> GetAll( ) =>
            _facebookDataHandler
                .Read<IEnumerable<SocialInsightsUser>,
                    DataArray<FacebookPage>>( "me/accounts",
                    MapMany,
                    Enumerable.Empty<SocialInsightsUser>( ),
                    new RequestFields
                    {
                        fields = "instagram_business_account{id,username,name,biography,followers_count}"
                    } );

        public IEnumerable<SocialInsightsUser> MapMany( DataArray<FacebookPage> dtoCollection ) =>
            dtoCollection?
                .Data
                .Select( x => x.Instagram )
                .Where( x => x != null )
                .Select( x =>
                    new SocialInsightsUser
                    {
                        Username = x.Username,
                        Id = x.Id,
                        Name = x.Name,
                        Bio = x.Bio,
                        Followers = x.Followers
                    } );
    }
}