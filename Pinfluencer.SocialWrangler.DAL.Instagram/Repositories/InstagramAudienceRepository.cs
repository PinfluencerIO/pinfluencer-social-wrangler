using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Repositories;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Instagram.Dtos;

namespace Pinfluencer.SocialWrangler.DAL.Instagram.Repositories
{
    public class InstagramAudienceRepository : FacebookRepository<InstagramAudienceRepository>, ISocialAudienceRepository
    {
        private readonly FacebookContext _facebookContext;
        private readonly ILoggerAdapter<InstagramAudienceRepository> _logger;
        private readonly CountryGetter _countryGetter;

        public InstagramAudienceRepository( FacebookContext facebookContext, ILoggerAdapter<InstagramAudienceRepository> logger, CountryGetter countryGetter ) : base( logger )
        {
            _facebookContext = facebookContext;
            _logger = logger;
            _countryGetter = countryGetter;
        }

        public OperationResult<IEnumerable<AudienceCount<LocationProperty>>> GetCountry( string instaId )
        {
            var ( fbResult, fbValidResult ) = ValidateFacebookCall( ( ) => _facebookContext
                    .Get( $"{instaId}/insights",
                        new BaseRequestInsightParams { metric = "audience_country", period = "lifetime" } ) );
            if( !fbValidResult )
            {
                _logger.LogError( "audience insights not fetched successfully" );
                return new OperationResult<IEnumerable<AudienceCount<LocationProperty>>>(
                    Enumerable.Empty<AudienceCount<LocationProperty>>( ),
                    OperationResultEnum.Failed );
            }
            var result = JsonConvert.DeserializeObject<DataArray<Metric<object>>>( fbResult );
            var genderAge =
                result.Data.First( ).Insights.First( ).Value as IEnumerable<KeyValuePair<string, JToken>>;
            var outputResult = new OperationResult<IEnumerable<AudienceCount<LocationProperty>>>(
                genderAge?.Select( x => new AudienceCount<LocationProperty>
                {
                    Count = ( int ) x.Value,
                    Property = new LocationProperty{ CountryCode = x.Key.Enumify<CountryEnum>( ), Country = _countryGetter.Countries[ x.Key.Enumify<CountryEnum>( ) ] }
                } ),
                OperationResultEnum.Success );
            _logger.LogInfo( "audience insights fetched successfully" );
            return outputResult;
        }

        public OperationResult<IEnumerable<AudienceCount<GenderAgeProperty>>> GetGenderAge( string instaId )
        {
            var ( fbResult, fbValidResult ) = ValidateFacebookCall( ( ) => _facebookContext
                    .Get( $"{instaId}/insights",
                        new BaseRequestInsightParams { metric = "audience_gender_age", period = "lifetime" } ) );
            if( !fbValidResult )
            {
                _logger.LogError( "audience insights not fetched successfully" );
                return new OperationResult<IEnumerable<AudienceCount<GenderAgeProperty>>>(
                    Enumerable.Empty<AudienceCount<GenderAgeProperty>>( ),
                    OperationResultEnum.Failed );
            }
            var result = JsonConvert.DeserializeObject<DataArray<Metric<object>>>( fbResult );
            var genderAge =
                result.Data.First( ).Insights.First( ).Value as IEnumerable<KeyValuePair<string, JToken>>;
            var outputResult = new OperationResult<IEnumerable<AudienceCount<GenderAgeProperty>>>(
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

                    return new AudienceCount<GenderAgeProperty>
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