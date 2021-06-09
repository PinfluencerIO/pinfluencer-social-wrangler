using System.Collections.Generic;
using System.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;
using Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract;

namespace Pinfluencer.SocialWrangler.DL.Facades
{
    public class SocialAudienceFacade : ISocialAudienceFacade
    {
        private readonly ISocialAudienceCountryRepository _socialAudienceCountryRepository;
        private readonly ISocialAudienceGenderAgeRepository _socialAudienceGenderAgeRepository;

        public SocialAudienceFacade( ISocialAudienceCountryRepository socialAudienceCountryRepository, ISocialAudienceGenderAgeRepository socialAudienceGenderAgeRepository )
        {
            _socialAudienceCountryRepository = socialAudienceCountryRepository;
            _socialAudienceGenderAgeRepository = socialAudienceGenderAgeRepository;
        }

        public ObjectResult<IEnumerable<AudiencePercentage<CountryProperty>>> GetAudienceCountryInsights(
            string id )
        {
            var result = _socialAudienceCountryRepository.Get( id );
            if( result.Status != OperationResultEnum.Success )
                return new ObjectResult<IEnumerable<AudiencePercentage<CountryProperty>>>(
                    Enumerable.Empty<AudiencePercentage<CountryProperty>>( ), OperationResultEnum.Failed );

            var totalFollowers = result.Value.Sum( x => x.Count );
            return new ObjectResult<IEnumerable<AudiencePercentage<CountryProperty>>>(
                result.Value.Select( x => new AudiencePercentage<CountryProperty>
                    { Percentage = ( double ) x.Count / ( double ) totalFollowers, Value = x.Property } ),
                OperationResultEnum.Success );
        }

        public ObjectResult<IEnumerable<AudiencePercentage<GenderEnum>>> GetAudienceGenderInsights( string id )
        {
            var result = _socialAudienceGenderAgeRepository.Get( id );
            if( result.Status != OperationResultEnum.Success )
                return new ObjectResult<IEnumerable<AudiencePercentage<GenderEnum>>>(
                    Enumerable.Empty<AudiencePercentage<GenderEnum>>( ), OperationResultEnum.Failed );

            var totalFollowers = result
                .Value
                .Sum( x => x.Count );
            var totalFollowersOfGenderType = result
                .Value
                .GroupBy( x => x.Property.Gender )
                .Select( x => ( x.Key, x.Sum( y => y.Count ) ) );
            return new ObjectResult<IEnumerable<AudiencePercentage<GenderEnum>>>(
                totalFollowersOfGenderType.Select( x => new AudiencePercentage<GenderEnum>
                    { Percentage = ( double ) x.Item2 / totalFollowers, Value = x.Key } ),
                OperationResultEnum.Success );
        }

        public ObjectResult<IEnumerable<AudiencePercentage<AgeProperty>>> GetAudienceAgeInsights( string id )
        {
            var result = _socialAudienceGenderAgeRepository.Get( id );
            if( result.Status != OperationResultEnum.Success )
                return new ObjectResult<IEnumerable<AudiencePercentage<AgeProperty>>>(
                    Enumerable.Empty<AudiencePercentage<AgeProperty>>( ), OperationResultEnum.Failed );

            var totalFollowers = result
                .Value
                .Sum( x => x.Count );
            var totalFollowersOfGenderType = result
                .Value
                .GroupBy( x => x.Property.AgeRange )
                .Select( x => ( x.Key, x.Sum( y => y.Count ) ) );
            return new ObjectResult<IEnumerable<AudiencePercentage<AgeProperty>>>(
                totalFollowersOfGenderType.Select( x => new AudiencePercentage<AgeProperty>
                {
                    Percentage = ( double ) x.Item2 / totalFollowers,
                    Value = new AgeProperty { Max = x.Key.Item2, Min = x.Key.Item1 }
                } ),
                OperationResultEnum.Success );
        }
    }
}