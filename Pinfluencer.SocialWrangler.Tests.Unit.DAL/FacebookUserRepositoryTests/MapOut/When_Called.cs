using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Common.Dtos;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.FacebookUserRepositoryTests.MapOut
{
    public class When_Called : Given_A_FacebookUserRepository
    {
        private SocialInfoUser _result;

        protected override void When( )
        {
            var facebookUser = new FacebookUser
            {
                Id = "123",
                Name = "Aidan Gannon",
                Birthday = new DateTime( 1999, 11, 26 ),
                Gender = GenderEnum.Male,
                Location = new FacebookPage
                {
                    Id = "4331",
                    Region = new Region
                    {
                        City = "London",
                        Country = "United Kingdom",
                        CountryCode = CountryEnum.GB
                    }
                }
            };
            _result = SUT.MapOut( facebookUser );
        }
        
        [ Test ]
        public void Then_Mapping_Is_Correct()
        {
            Assert.AreEqual( "123", _result.Id );
            Assert.AreEqual( 21, _result.Age );
            Assert.AreEqual( GenderEnum.Male, _result.Gender );
            Assert.AreEqual( "Aidan Gannon", _result.Name );
            Assert.AreEqual( "United Kingdom", _result.Location.Country );
            Assert.AreEqual( CountryEnum.GB, _result.Location.CountryCode );
            Assert.AreEqual( "London", _result.Location.City );
        }
    }
}