using System;
using System.Collections.Generic;
using System.Net.Http;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.BubbleHandlerTests.Read.Shared;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.BubbleHandlerTests.Read
{
    [ TestFixtureSource( nameof( fixture ) ) ]
    public class When_Network_Error_Or_Parsing_Error_Occurs : When_Error_Occurs
    {
        private readonly Exception _exception;

        public When_Network_Error_Or_Parsing_Error_Occurs( Exception exception ) { _exception = exception; }

        private static IEnumerable<Exception> fixture = new Exception [ ]
        {
            new ArgumentException( "uri was null" ),
            new HttpRequestException( "network error" )
        };

        protected override void When( )
        {
            MockBubbleClient
                .Get<Dto>( Arg.Any<string>( ) )
                .Throws( _exception );
            Result = SutCall( );
        }
    }
}