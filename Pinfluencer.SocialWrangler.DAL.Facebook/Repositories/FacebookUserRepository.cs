using System;
using System.Collections;
using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Repositories;
using Pinfluencer.SocialWrangler.Core.Models;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Common.Dtos;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Repositories
{
    public class FacebookUserRepository :
        ISocialInfoUserRepository,
        IDataMappableOut<SocialInfoUser,
            FacebookUser>
    {
        private readonly IFacebookDataHandler<FacebookUserRepository> _facebookDataHandler;
        private readonly IDateTimeAdapter _dateTimeAdapter;

        public FacebookUserRepository( IFacebookDataHandler<FacebookUserRepository> facebookDataHandler, IDateTimeAdapter dateTimeAdapter )
        {
            _facebookDataHandler = facebookDataHandler;
            _dateTimeAdapter = dateTimeAdapter;
        }

        public OperationResult<SocialInfoUser> Get( ) =>
            _facebookDataHandler
                .Read<SocialInfoUser,FacebookUser>( "me",
                    MapOut,
                    new SocialInfoUser( ),
                    new RequestFields{ fields = "birthday,location{location{city,country,country_code}},gender,name" } );

        public SocialInfoUser MapOut( FacebookUser dto ) =>
            new SocialInfoUser
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
}