using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.FrontFacing.Social;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Repositories
{
    [ Obsolete ]
    public class InstagramAudienceRepository : FacebookRepository<InstagramAudienceRepository>,
        ISocialAudienceRepository
    {
        private readonly ICountryGetter _countryGetter;
        private readonly IFacebookDecorator _facebookDecorator;
        private readonly ILoggerAdapter<InstagramAudienceRepository> _logger;

        public InstagramAudienceRepository( IFacebookDecorator facebookDecorator,
            ILoggerAdapter<InstagramAudienceRepository> logger, ICountryGetter countryGetter ) : base( logger )
        {
            _facebookDecorator = facebookDecorator;
            _logger = logger;
            _countryGetter = countryGetter;
        }

        public OperationResult<IEnumerable<AudienceCount<LocationProperty>>> GetCountry( string instaId )
        {
            var (fbResult, fbValidResult) = ValidateFacebookCall( ( ) => _facebookDecorator
                .Get<DataArray<Metric<object>>>( $"{instaId}/insights",
                    new BaseRequestInsightParams { metric = "audience_country", period = "lifetime" } ) );
            if( !fbValidResult )
            {
                _logger.LogError( "audience insights not fetched successfully" );
                return new OperationResult<IEnumerable<AudienceCount<LocationProperty>>>(
                    Enumerable.Empty<AudienceCount<LocationProperty>>( ),
                    OperationResultEnum.Failed );
            }
            var genderAge =
                fbResult.Data.First( ).Insights.First( ).Value as IEnumerable<KeyValuePair<string, JToken>>;
            var outputResult = new OperationResult<IEnumerable<AudienceCount<LocationProperty>>>(
                genderAge?.Select( x => new AudienceCount<LocationProperty>
                {
                    Count = ( int ) x.Value,
                    Property = new LocationProperty
                    {
                        CountryCode = x.Key.Enumify<CountryEnum>( ),
                        Country = _countryGetter.Countries[ x.Key.Enumify<CountryEnum>( ) ]
                    }
                } ),
                OperationResultEnum.Success );
            _logger.LogInfo( "audience insights fetched successfully" );
            return outputResult;
        }

        public OperationResult<IEnumerable<AudienceCount<GenderAgeProperty>>> GetGenderAge( string instaId )
        {
            var (fbResult, fbValidResult) = ValidateFacebookCall( ( ) => _facebookDecorator
                .Get<DataArray<Metric<object>>>( $"{instaId}/insights",
                    new BaseRequestInsightParams { metric = "audience_gender_age", period = "lifetime" } ) );
            if( !fbValidResult )
            {
                _logger.LogError( "audience insights not fetched successfully" );
                return new OperationResult<IEnumerable<AudienceCount<GenderAgeProperty>>>(
                    Enumerable.Empty<AudienceCount<GenderAgeProperty>>( ),
                    OperationResultEnum.Failed );
            }
            var genderAge =
                fbResult.Data.First( ).Insights.First( ).Value as IEnumerable<KeyValuePair<string, JToken>>;
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