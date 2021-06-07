using System;
using System.Linq;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.DAL.Core.Dtos.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramContentRepositoryTests.MapMany
{
    public class When_Called : Given_An_InstagramContentRepository
    {
        [ Test ]
        public void Then_Mapping_Was_Correct( )
        {
            var data = new DataArray<InstagramContent>
            {
                Data = new [ ]
                {
                    new InstagramContent
                    {
                        Id = "123235342",
                        UploadTime = new DateTime( 2021, 5, 5 )
                    },
                    new InstagramContent
                    {
                        Id = "547385748",
                        UploadTime = new DateTime( 2021, 11, 12 )
                    },
                    new InstagramContent
                    {
                        Id = "547385748",
                        UploadTime = new DateTime( 2020, 11, 12 )
                    }
                }
            };
            var result = SUT.MapMany( data );
            CollectionAssert.AreEquivalent( new []
            {
                ( "123235342", "05/05/2021" ),
                ( "123235342", "11/12/2021" ),
                ( "123235342", "11/12/2020" )
            }, result.Select( x => ( x.Id, x.TimeOfUpload.ToString( "MM/dd/yyyy" ) ) ) );
        }
    }
}