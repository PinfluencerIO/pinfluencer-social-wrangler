using Bootstrapping.Services.Enum;
using Tests.Unit.BLL.InstagramFetcher.InstaInsightsCollectionService.GetUserInsightsTests.Shared;

namespace Tests.Unit.BLL.InstagramFetcher.InstaInsightsCollectionService.GetUserInsightsTests.AgeRangeTests.Shared
{
    public abstract class When_Age_Range_Varies : When_Get_User_Insights_Is_Called
    {
        protected int AgeMin;
        protected int AgeMax;

        protected override void When()
        {
            AudienceGenderAgeColleciton = GetSingleAudienceGenderAgeColleciton("male", AgeMin, AgeMax, 2);
            AudienceGenderAgeOperationResult = OperationResultEnum.Success;
            SetDefaultAudienceCountryColleciton();
            SetDefaultImpressionsColleciton();

            base.When();
        }
    }
}