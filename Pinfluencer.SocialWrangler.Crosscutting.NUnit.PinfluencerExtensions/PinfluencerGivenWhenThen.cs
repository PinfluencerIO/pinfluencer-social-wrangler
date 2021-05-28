using System;
using NSubstitute;
using Pinfluencer.SocialWrangler.Core.Interfaces.Models;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.Extensions;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;

namespace Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions
{
    public class PinfluencerGivenWhenThen<T> : GivenWhenThen<T> where T : class
    {
        protected ISocialInfoUser GetSocialInfoUser( FakeSocialInfoUserProps socialInfoUserProps ) => FakeSocialInfoUserModel.GetFake( MockDateTime, socialInfoUserProps );

        protected ILoggerAdapter<T> MockLogger;

        protected override void Given( )
        {
            MockLogger = Substitute.For<ILoggerAdapter<T>>( );
        }

        protected IDateTimeAdapter MockDateTime { get; } = Substitute.For<IDateTimeAdapter>( );

        protected DateTime CurrentTime
        {
            set => MockDateTime
                .Now( )
                .Returns( value );
        }
        
        
    }
}