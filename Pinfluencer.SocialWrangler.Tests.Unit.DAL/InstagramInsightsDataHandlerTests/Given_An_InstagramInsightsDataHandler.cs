using System;
using System.Collections.Generic;
using NSubstitute;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.DAL.Facebook.Handlers;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramInsightsDataHandlerTests
{
    public class Given_An_InstagramInsightsDataHandler : DataGivenWhenThen<InstagramInsightsDataHandler<SocialInsightsBase>>
    {
        protected new IFacebookDataHandler<SocialInsightsBase> MockFacebookDataHandler;
        
        protected static readonly IEnumerable<SocialInsightsBase> SocialInsightsBase = new [ ]
        {
            new SocialInsightsBase
            {
                Count = 6,
                Time = new DateTime( 2021, 11, 26 )
            },
            new SocialInsightsBase
            {
                Count = 54,
                Time = new DateTime( 2021, 11, 26 )
            },
            new SocialInsightsBase
            {
                Count = 65,
                Time = new DateTime( 2021, 11, 26 )
            }
        };
        
        protected override void Given( )
        {
            base.Given( );
            MockFacebookDataHandler = Substitute.For<IFacebookDataHandler<SocialInsightsBase>>( );
            SUT = new InstagramInsightsDataHandler<SocialInsightsBase>( MockFacebookDataHandler );
        }
    }
}