using System;
using NSubstitute;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.Crosscutting;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.Extensions;

namespace Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions
{
    public class PinfluencerGivenWhenThen<T> : GivenWhenThen<T> where T : class
    {
        protected ILoggerAdapter<T> MockLogger;

        protected IDateTimeAdapter MockDateTime { get; } = Substitute.For<IDateTimeAdapter>( );

        protected DateTime CurrentTime
        {
            get => MockDateTime.Now( );
            set => MockDateTime
                .Now( )
                .Returns( value );
        }

        protected override void Given( ) { MockLogger = Substitute.For<ILoggerAdapter<T>>( ); }
    }
}