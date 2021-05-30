using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
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
            var genderAge =
                dtoCollection.Data.First( ).Insights.First( ).Value as IEnumerable<KeyValuePair<string, JToken>>;
            var outputResult =
                genderAge.Select( x =>
                {
                    var genderString = x.Key.Split( "." )[ 0 ];
                    int ageMin;
                    int? ageMax;
                    if( x.Key.Split( "." )[ 1 ].Contains( "+" ) )
                    {
                        ageMin = int.Parse( x.Key.Split( "." )[ 1 ].Split( "+" )[ 0 ] );
                        ageMax = null;
                    }
                    else
                    {
                        ageMin = int.Parse( x.Key.Split( "." )[ 1 ].Split( "-" )[ 0 ] );
                        ageMax = int.Parse( x.Key.Split( "." )[ 1 ].Split( "-" )[ 1 ] );
                    }
                    return new AudienceCount<GenderAgeProperty>
                    {
                        Count = ( int ) x.Value,
                        Property = new GenderAgeProperty
                        {
                            Gender = genderString switch
                            {
                                "F" => GenderEnum.Female,
                                "M" => GenderEnum.Male,
                                "U" => GenderEnum.Unknown,
                                _ => GenderEnum.Unknown
                            },
                            AgeRange = new Tuple<int, int?>( ageMin, ageMax )
                        }
                    };
                } );
            return outputResult;
        }
    }
}