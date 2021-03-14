using Bootstrapping.Services.Enum;
using Tests.Integration.BLL.InstagramFetcher.InstaInsightsCollectionFactory.GetUserInsightsTests.Shared;

namespace Tests.Integration.BLL.InstagramFetcher.InstaInsightsCollectionFactory.GetUserInsightsTests.AgeRangeTests.Shared
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