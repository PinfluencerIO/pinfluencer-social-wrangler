using NSubstitute;
using Pinfluencer.SocialWrangler.DL.Facades;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DL.SocialUserFacadeTests
{
    public abstract class
        Given_A_SocialUserFacade : DataGivenWhenThen<SocialInsightUserFacade>
    {
        protected IInsightsSocialUserRepository InsightsSocialUserRepository;

        protected override void Given( )
        {
            base.Given( );
            
            InsightsSocialUserRepository = Substitute.For<IInsightsSocialUserRepository>( );

            SUT = new SocialInsightUserFacade( InsightsSocialUserRepository );
        }
    }
}