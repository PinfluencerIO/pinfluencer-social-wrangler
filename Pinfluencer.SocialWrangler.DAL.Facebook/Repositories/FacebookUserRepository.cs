using System;
using Aidan.Common.Core;
using Aidan.Common.Core.Interfaces.Contract;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.DAL.Common.Dtos;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Repositories
{
    public class FacebookUserRepository :
        ISocialInfoUserRepository,
        IDataMappableOut<SocialInfoUser,
            FacebookUser>
    {
        private readonly IDateTimeAdapter _dateTimeAdapter;
        private readonly IFacebookDataHandler<FacebookUserRepository> _facebookDataHandler;

        public FacebookUserRepository( IFacebookDataHandler<FacebookUserRepository> facebookDataHandler,
            IDateTimeAdapter dateTimeAdapter )
        {
            _facebookDataHandler = facebookDataHandler;
            _dateTimeAdapter = dateTimeAdapter;
        }

        public SocialInfoUser MapOut( FacebookUser dto )
        {
            return new SocialInfoUser
            {
                Id = dto.Id,
                Name = dto.Name,
                Gender = dto.Gender,
                Age = new DateTime( _dateTimeAdapter.Now( ).Subtract( dto.Birthday ).Ticks ).Year - 1,
                Location = new LocationProperty
                {
                    Country = dto.Location.Region.Country,
                    City = dto.Location.Region.City,
                    CountryCode = dto.Location.Region.CountryCode
                }
            };
        }

        public ObjectResult<SocialInfoUser> Get( )
        {
            return _facebookDataHandler
                .Read<SocialInfoUser, FacebookUser>( "me",
                    MapOut,
                    new SocialInfoUser( ),
                    new RequestFields
                        { fields = "birthday,location{location{city,country,country_code}},gender,name" } );
        }
    }
}