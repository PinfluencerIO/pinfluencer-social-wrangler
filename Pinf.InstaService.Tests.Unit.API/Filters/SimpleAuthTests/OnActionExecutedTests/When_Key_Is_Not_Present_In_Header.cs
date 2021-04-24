using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Tests.Unit.API.Filters.SimpleAuthTests.OnActionExecutedTests.Shared;

namespace Pinf.InstaService.Tests.Unit.API.Filters.SimpleAuthTests.OnActionExecutedTests
{
    [ TestFixtureSource( nameof( Headers ) ) ]
    public class When_Key_Is_Not_Present_In_Header : When_Error_Occurs
    {
        private readonly Dictionary<string, StringValues> _headers;

        private static IEnumerable<Dictionary<string, StringValues>> Headers( )
        {
            return new [ ]
            {
                new Dictionary<string, StringValues>( ),
                new Dictionary<string, StringValues> { { "Invalid-Key-Name", ApiKey } }
            };
        }

        public When_Key_Is_Not_Present_In_Header( Dictionary<string, StringValues> headers ) { _headers = headers; }

        protected override Dictionary<string, StringValues> SetupHeaders( ) { return _headers; }

        protected override void When( )
        {
            base.When( );
            MockConfiguration[ ApiKeyName ].Returns( ApiKey );
            Sut.OnActionExecuted( MockActionExecutedContext );
        }

        [ Test ]
        public void Then_Error_Message_Is_Valid( ) { Assert.AreEqual( "api key was not received", ErrorMessage ); }
    }
}