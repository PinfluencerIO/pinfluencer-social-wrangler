using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramAudienceRepositoryTests.Shared
{
    public abstract class When_Any_Called<T> : Given_A_InstagramAudienceRepository
    {
        protected OperationResult<IEnumerable<AudienceCount<T>>> Result;

        [ Test ]
        public void Then_Graph_Api_Was_Called_Once( )
        {
            MockFacebookDecorator
                .Received( 1 )
                .Get<DataArray<Metric<object>>>( Arg.Any<string>( ), Arg.Any<object>( ) );
        }

        [ Test ]
        public void Then_Correct_Api_Endpoint_Was_Called( )
        {
            MockFacebookDecorator
                .Received( )
                .Get<DataArray<Metric<object>>>( "123/insights", Arg.Any<object>( ) );
        }
    }
}