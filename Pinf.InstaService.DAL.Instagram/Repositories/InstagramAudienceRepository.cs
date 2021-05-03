﻿using System;
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
    public class InstagramAudienceRepository : FacebookRepository<InstagramAudienceRepository>, IInstaAudienceInsightsRepository
    {
        private readonly FacebookContext _facebookContext;
        private readonly ILoggerAdapter<InstagramAudienceRepository> _logger;

        public InstagramAudienceRepository( FacebookContext facebookContext, ILoggerAdapter<InstagramAudienceRepository> logger ) : base( logger )
        {
            _facebookContext = facebookContext;
            _logger = logger;
        }

        public OperationResult<IEnumerable<InstaFollowersInsight<CountryProperty>>> GetCountry( string instaId )
        {
            var ( fbResult, fbValidResult ) = ValidateFacebookCall( ( ) => _facebookContext
                    .Get( $"{instaId}/insights",
                        new RequestInsightLifetimeParams { metric = "audience_country" } ) );
            if( !fbValidResult )
            {
                _logger.LogError( "audience insights not fetched successfully" );
                return new OperationResult<IEnumerable<InstaFollowersInsight<CountryProperty>>>(
                    Enumerable.Empty<InstaFollowersInsight<CountryProperty>>( ),
                    OperationResultEnum.Failed );
            }
            var result = JsonConvert.DeserializeObject<DataArray<Metric<object>>>( fbResult );
            var genderAge =
                result.Data.First( ).Insights.First( ).Value as IEnumerable<KeyValuePair<string, JToken>>;
            var outputResult = new OperationResult<IEnumerable<InstaFollowersInsight<CountryProperty>>>(
                genderAge?.Select( x => new InstaFollowersInsight<CountryProperty>
                {
                    Count = ( int ) x.Value,
                    Property = new CountryProperty
                    {
                        Country = new RegionInfo( x.Key )
                    }
                } ),
                OperationResultEnum.Success );
            _logger.LogInfo( "audience insights fetched successfully" );
            return outputResult;
        }

        public OperationResult<IEnumerable<InstaFollowersInsight<GenderAgeProperty>>> GetGenderAge( string instaId )
        {
            var ( fbResult, fbValidResult ) = ValidateFacebookCall( ( ) => _facebookContext
                    .Get( $"{instaId}/insights",
                        new RequestInsightLifetimeParams { metric = "audience_gender_age" } ) );
            if( !fbValidResult )
            {
                _logger.LogError( "audience insights not fetched successfully" );
                return new OperationResult<IEnumerable<InstaFollowersInsight<GenderAgeProperty>>>(
                    Enumerable.Empty<InstaFollowersInsight<GenderAgeProperty>>( ),
                    OperationResultEnum.Failed );
            }
            var result = JsonConvert.DeserializeObject<DataArray<Metric<object>>>( fbResult );
            var genderAge =
                result.Data.First( ).Insights.First( ).Value as IEnumerable<KeyValuePair<string, JToken>>;
            var outputResult = new OperationResult<IEnumerable<InstaFollowersInsight<GenderAgeProperty>>>(
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

                    return new InstaFollowersInsight<GenderAgeProperty>
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