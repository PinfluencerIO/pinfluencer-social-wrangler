using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Repositories
{
    public class InstagramAudienceCountryRepository : FacebookRepository<InstagramAudienceCountryRepository>
    {
        private readonly FacebookDecorator _facebookDecorator;
        private readonly ILoggerAdapter<InstagramAudienceCountryRepository> _logger;
        private readonly CountryGetter _countryGetter;

        public InstagramAudienceCountryRepository( FacebookDecorator facebookDecorator, ILoggerAdapter<InstagramAudienceCountryRepository> logger, CountryGetter countryGetter ) : base( logger )
        {
            _facebookDecorator = facebookDecorator;
            _logger = logger;
            _countryGetter = countryGetter;
        }
        
        public OperationResult<IEnumerable<AudienceCount<LocationProperty>>> Get( string instaId )
        {
            var ( fbResult, fbValidResult ) = ValidateFacebookCall( ( ) => _facebookDecorator
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
    }
}