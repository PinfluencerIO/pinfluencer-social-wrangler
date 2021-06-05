using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Repositories
{
    public class InstagramAudienceCountryRepository :
        InstagramAudienceRepositoryBase<InstagramAudienceCountryRepository, CountryProperty>
    {
        private readonly CountryGetter _countryGetter;

        public InstagramAudienceCountryRepository( CountryGetter countryGetter,
            IFacebookDataHandler<InstagramAudienceCountryRepository> facebookDataHandler ) : base( facebookDataHandler )
        {
            _countryGetter = countryGetter;
        }

        public override OperationResult<IEnumerable<AudienceCount<CountryProperty>>> Get( string instaId )
        {
            return FacebookDataHandler
                .Read<IEnumerable<AudienceCount<CountryProperty>>, DataArray<Metric<object>>>( $"{instaId}/insights",
                    MapMany, Enumerable.Empty<AudienceCount<CountryProperty>>( ),
                    new RequestInsightParams { metric = "audience_country", period = "lifetime" } );
        }

        public override IEnumerable<AudienceCount<CountryProperty>> MapMany( DataArray<Metric<object>> dtoCollection )
        {
            var countries =
                dtoCollection.Data.First( ).Insights.First( ).Value as IEnumerable<KeyValuePair<string, JToken>>;
            var outputResult =
                countries?.Select( x => new AudienceCount<CountryProperty>
                {
                    Count = ( int ) x.Value,
                    Property = new CountryProperty
                    {
                        CountryCode = x.Key.Enumify<CountryEnum>( ),
                        Country = _countryGetter.Countries[ x.Key.Enumify<CountryEnum>( ) ]
                    }
                } );
            return outputResult;
        }
    }
}