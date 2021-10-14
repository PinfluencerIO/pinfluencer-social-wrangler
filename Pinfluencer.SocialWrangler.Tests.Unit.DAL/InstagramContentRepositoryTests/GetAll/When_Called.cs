using System;
using System.Collections.Generic;
using System.Linq;
using Aidan.Common.Core;
using Aidan.Common.Core.Enum;
using NSubstitute;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Core.Dtos.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramContentRepositoryTests.GetAll
{
    [ TestFixtureSource( nameof( data ) ) ]
    public class When_Called : Given_An_InstagramContentRepository
    {
        private readonly IEnumerable<Content> _content;
        private readonly OperationResultEnum _status;

        private static object [ ] data =
        {
            new object[]
            {
                Enumerable.Empty<Content>(  ),
                OperationResultEnum.Failed
            },
            new object[]
            {
                new []
                {
                    new Content
                    {
                        Id = "12324343"
                    },
                    new Content
                    {
                        Id = "543543"
                    },
                    new Content
                    {
                        Id = "432432"
                    }
                },
                OperationResultEnum.Success
            }
        };

        private ObjectResult<IEnumerable<Content>> _result;

        public When_Called( IEnumerable<Content> content, OperationResultEnum status )
        {
            _content = content;
            _status = status;
        }

        protected override void When( )
        {
            MockFacebookDataHandler
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<InstagramContent>,IEnumerable<Content>>>( ),
                    Arg.Any<IEnumerable<Content>>( ) )
                .Returns( new ObjectResult<IEnumerable<Content>>
                {
                    Status = _status,
                    Value = _content
                } );
            _result = SUT.GetAll( "123" );
        }

        [ Test ]
        public void Then_Valid_Call_Was_Made( )
        {
            MockFacebookDataHandler
                .Received( 1 )
                .Read( Arg.Any<string>( ),
                    Arg.Any<Func<DataArray<InstagramContent>,IEnumerable<Content>>>( ),
                    Arg.Any<IEnumerable<Content>>( ) );
            MockFacebookDataHandler
                .Received( )
                .Read<IEnumerable<Content>,DataArray<InstagramContent>>( "123/media",
                    SUT.MapMany,
                    Arg.Is<IEnumerable<Content>>( t => !t.Any( ) ) );
        }
        
        [ Test ]
        public void Then_Valid_Status_Was_Returned( )
        {
            Assert.AreEqual( _status, _result.Status );
        }
    }
}