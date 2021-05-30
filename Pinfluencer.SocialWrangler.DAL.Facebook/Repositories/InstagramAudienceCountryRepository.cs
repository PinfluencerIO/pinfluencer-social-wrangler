﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Repositories
{
    public class InstagramAudienceCountryRepository :
        IDataCollectionMappable<IEnumerable<AudienceCount<LocationProperty>>,
            DataArray<Metric<object>>>
    {
        private readonly IFacebookDataHandler<InstagramAudienceCountryRepository> _facebookDataHandler;
        private readonly CountryGetter _countryGetter;
        
        public InstagramAudienceCountryRepository( IFacebookDataHandler<InstagramAudienceCountryRepository> facebookDataHandler, CountryGetter countryGetter )
        {
            _facebookDataHandler = facebookDataHandler;
            _countryGetter = countryGetter;
        }

        public OperationResult<IEnumerable<AudienceCount<LocationProperty>>> Get( string instaId ) =>
            _facebookDataHandler
                .Read<IEnumerable<AudienceCount<LocationProperty>>, DataArray<Metric<object>>>( $"{instaId}/insights",
                    MapMany, Enumerable.Empty<AudienceCount<LocationProperty>>( ),
                    new RequestInsightParams { metric = "audience_country", period = "lifetime" } );

        public IEnumerable<AudienceCount<LocationProperty>> MapMany( DataArray<Metric<object>> dtoCollection )
        {
            var genderAge =
                dtoCollection.Data.First( ).Insights.First( ).Value as IEnumerable<KeyValuePair<string, JToken>>;
            return genderAge?.Select( x => new AudienceCount<LocationProperty>
            {
                Count = ( int ) x.Value,
                Property = new LocationProperty
                {
                    CountryCode = x.Key.Enumify<CountryEnum>( ),
                    Country = _countryGetter.Countries[ x.Key.Enumify<CountryEnum>( ) ]
                }
            } );
        }
    }
}