using System;
using System.Collections.Generic;
using System.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.DAL.Common.Dtos;
using Pinfluencer.SocialWrangler.DAL.Core.Dtos.Dtos;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Repositories
{
    public class InstagramUserRepository :
        IInsightsSocialUserRepository,
        IDataCollectionMappable<IEnumerable<SocialInsightsUser>, DataArray<FacebookPage>>
    {
        private readonly IFacebookDataHandler<InstagramUserRepository> _facebookDataHandler;
        private readonly IFacebookDecorator _facebookDecorator;

        public InstagramUserRepository( IFacebookDecorator facebookDecorator,
            IFacebookDataHandler<InstagramUserRepository> facebookDataHandler )
        {
            _facebookDecorator = facebookDecorator;
            _facebookDataHandler = facebookDataHandler;
        }

        public IEnumerable<SocialInsightsUser> MapMany( DataArray<FacebookPage> dtoCollection )
        {
            return dtoCollection?
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

        public ObjectResult<SocialInsightsUser> Get( string id ) { throw new NotImplementedException( ); }

        public ObjectResult<IEnumerable<SocialInsightsUser>> GetAll( )
        {
            return _facebookDataHandler
                .Read<IEnumerable<SocialInsightsUser>,
                    DataArray<FacebookPage>>( "me/accounts",
                    MapMany,
                    Enumerable.Empty<SocialInsightsUser>( ),
                    new RequestFields
                    {
                        fields = "instagram_business_account{id,username,name,biography,followers_count}"
                    } );
        }
    }
}