using System;
using System.Collections.Generic;
using System.Linq;
using Facebook;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.DAL.Common;
using Pinf.InstaService.DAL.Instagram.Dtos;

namespace Pinf.InstaService.DAL.Instagram.Repositories
{
    public class InstagramAudienceRepository : IInstaAudienceInsightsRepository
    {
        private readonly FacebookContext _facebookContext;

        public InstagramAudienceRepository( FacebookContext facebookContext ) { _facebookContext = facebookContext; }

        public OperationResult<IEnumerable<InstaFollowersInsight<CountryProperty>>> GetCountry( string instaId )
        {
            throw new NotImplementedException( );
        }

        public OperationResult<IEnumerable<InstaFollowersInsight<GenderAgeProperty>>> GetGenderAge( string instaId )
        {
            var fbResult = _facebookContext
                .Get( $"{instaId}/insights", new RequestInsightLifetimeParams{ metric = "audience_gender_age" } );
            var result = JsonConvert.DeserializeObject<DataArray<Metric<object>>>( fbResult );
            var genderAge = result.Data.First( ).Insights.First( ).Value as IEnumerable<KeyValuePair<string, JToken>>;
            return new OperationResult<IEnumerable<InstaFollowersInsight<GenderAgeProperty>>>(
                genderAge.Select( x =>
                {
                    var generString = x.Key.Split( "." )[ 0 ];
                    var ageMin = int.Parse( x.Key.Split( "." )[ 1 ].Split( "-" )[ 0 ] );
                    var ageMax = int.Parse( x.Key.Split( "." )[ 1 ].Split( "-" )[ 1 ] );
                    return new InstaFollowersInsight<GenderAgeProperty>
                    {
                        Count = ( int ) x.Value,
                        Property = new GenderAgeProperty
                        {
                            Gender = generString == "F" ? GenderEnum.Female : GenderEnum.Male,
                            AgeRange = new Tuple<int, int>( ageMin, ageMax )
                        }
                    };
                } ),
                OperationResultEnum.Success );
        }
    }
}