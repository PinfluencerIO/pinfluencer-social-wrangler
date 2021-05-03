using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Facebook;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.DAL.Common;
using Pinf.InstaService.DAL.Instagram.Dtos;

namespace Pinf.InstaService.DAL.Instagram.Repositories
{
    public class InstagramAudienceRepository : FacebookRepository<InstagramAudienceRepository>, IInstaAudienceRepository
    {
        private readonly FacebookContext _facebookContext;
        private readonly ILoggerAdapter<InstagramAudienceRepository> _logger;

        public InstagramAudienceRepository( FacebookContext facebookContext, ILoggerAdapter<InstagramAudienceRepository> logger ) : base( logger )
        {
            _facebookContext = facebookContext;
            _logger = logger;
        }

        public OperationResult<IEnumerable<FollowersInsight<RegionInfo>>> GetCountry( string instaId )
        {
            var ( fbResult, fbValidResult ) = ValidateFacebookCall( ( ) => _facebookContext
                    .Get( $"{instaId}/insights",
                        new BaseRequestInsightParams { metric = "audience_gender_age", period = "lifetime" } ) );
            if( !fbValidResult )
            {
                _logger.LogError( "audience insights not fetched successfully" );
                return new OperationResult<IEnumerable<FollowersInsight<RegionInfo>>>(
                    Enumerable.Empty<FollowersInsight<RegionInfo>>( ),
                    OperationResultEnum.Failed );
            }
            var result = JsonConvert.DeserializeObject<DataArray<Metric<object>>>( fbResult );
            var genderAge =
                result.Data.First( ).Insights.First( ).Value as IEnumerable<KeyValuePair<string, JToken>>;
            var outputResult = new OperationResult<IEnumerable<FollowersInsight<RegionInfo>>>(
                genderAge?.Select( x => new FollowersInsight<RegionInfo>
                {
                    Count = ( int ) x.Value,
                    Property = new RegionInfo( x.Key )
                } ),
                OperationResultEnum.Success );
            _logger.LogInfo( "audience insights fetched successfully" );
            return outputResult;
        }

        public OperationResult<IEnumerable<FollowersInsight<GenderAgeProperty>>> GetGenderAge( string instaId )
        {
            var ( fbResult, fbValidResult ) = ValidateFacebookCall( ( ) => _facebookContext
                    .Get( $"{instaId}/insights",
                        new BaseRequestInsightParams { metric = "audience_gender_age", period = "lifetime" } ) );
            if( !fbValidResult )
            {
                _logger.LogError( "audience insights not fetched successfully" );
                return new OperationResult<IEnumerable<FollowersInsight<GenderAgeProperty>>>(
                    Enumerable.Empty<FollowersInsight<GenderAgeProperty>>( ),
                    OperationResultEnum.Failed );
            }
            var result = JsonConvert.DeserializeObject<DataArray<Metric<object>>>( fbResult );
            var genderAge =
                result.Data.First( ).Insights.First( ).Value as IEnumerable<KeyValuePair<string, JToken>>;
            var outputResult = new OperationResult<IEnumerable<FollowersInsight<GenderAgeProperty>>>(
                genderAge.Select( x =>
                {
                    var generString = x.Key.Split( "." )[ 0 ];
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

                    return new FollowersInsight<GenderAgeProperty>
                    {
                        Count = ( int ) x.Value,
                        Property = new GenderAgeProperty
                        {
                            Gender = generString == "F" ? GenderEnum.Female : GenderEnum.Male,
                            AgeRange = new Tuple<int, int?>( ageMin, ageMax )
                        }
                    };
                } ),
                OperationResultEnum.Success );
            _logger.LogInfo( "audience insights fetched successfully" );
            return outputResult;
        }
    }
}