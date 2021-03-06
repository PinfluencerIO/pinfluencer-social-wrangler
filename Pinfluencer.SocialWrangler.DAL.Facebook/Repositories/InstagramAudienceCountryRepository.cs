using System.Collections.Generic;
using System.Linq;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using Aidan.Common.Core.Interfaces.Contract;
using Aidan.Common.Utils.Utils;
using Newtonsoft.Json.Linq;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Core.Dtos.Dtos;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Repositories
{
    public class InstagramAudienceCountryRepository :
        InstagramAudienceRepositoryBase<InstagramAudienceCountryRepository, CountryProperty>, ISocialAudienceCountryRepository
    {
        private readonly ICountryGetter _countryGetter;

        public InstagramAudienceCountryRepository( ICountryGetter countryGetter,
            IFacebookDataHandler<InstagramAudienceCountryRepository> facebookDataHandler ) : base( facebookDataHandler )
        {
            _countryGetter = countryGetter;
        }

        public override ObjectResult<IEnumerable<AudienceCount<CountryProperty>>> Get( string instaId )
        {
            return FacebookDataHandler
                .Read<IEnumerable<AudienceCount<CountryProperty>>, DataArray<Metric<object>>>( $"{instaId}/insights",
                    MapMany, Enumerable.Empty<AudienceCount<CountryProperty>>( ),
                    new BaseRequestInsightParams { metric = "audience_country", period = "lifetime" } );
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