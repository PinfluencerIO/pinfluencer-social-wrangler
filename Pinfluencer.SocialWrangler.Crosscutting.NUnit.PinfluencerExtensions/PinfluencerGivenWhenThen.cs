using System;
using NSubstitute;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.Extensions;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;

namespace Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions
{
    public class PinfluencerGivenWhenThen<T> : GivenWhenThen<T> where T : class
    {
        protected ILoggerAdapter<T> MockLogger;

        protected override void Given( )
        {
            MockLogger = Substitute.For<ILoggerAdapter<T>>( );
        }

        protected IDateTimeAdapter MockDateTime { get; } = Substitute.For<IDateTimeAdapter>( );

        protected DateTime CurrentTime
        {
            get => MockDateTime.Now( );
            set => MockDateTime
                .Now( )
                .Returns( value );
        }
    }
}