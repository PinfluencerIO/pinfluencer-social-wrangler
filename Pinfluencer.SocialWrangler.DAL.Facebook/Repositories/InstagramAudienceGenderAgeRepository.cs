using System.Collections.Generic;
using System.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Repositories
{
    public class InstagramAudienceGenderAgeRepository :
        InstagramAudienceRepositoryBase<InstagramAudienceGenderAgeRepository,GenderAgeProperty>
    {
        public InstagramAudienceGenderAgeRepository( IFacebookDataHandler<InstagramAudienceGenderAgeRepository> facebookDataHandler ) : base( facebookDataHandler )
        {
        }

        public override OperationResult<IEnumerable<AudienceCount<GenderAgeProperty>>> Get( string instaId ) =>
            FacebookDataHandler
                .Read<IEnumerable<AudienceCount<GenderAgeProperty>>, DataArray<Metric<object>>>( $"{instaId}/insights",
                    MapMany, Enumerable.Empty<AudienceCount<GenderAgeProperty>>( ),
                    new RequestInsightParams { metric = "audience_gender_age", period = "lifetime" } );

        public override IEnumerable<AudienceCount<GenderAgeProperty>> MapMany( DataArray<Metric<object>> dtoCollection )
        {
            return Enumerable.Empty<AudienceCount<GenderAgeProperty>>( );
        }
    }
}