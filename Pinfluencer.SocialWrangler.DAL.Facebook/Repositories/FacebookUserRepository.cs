﻿using System.Collections;
using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Models;
using Pinfluencer.SocialWrangler.Core.Interfaces.Repositories;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.DAL.Common.Dtos;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Repositories
{
    public class FacebookUserRepository :
        ISocialInfoUserRepository,
        IDataMappable<ISocialInfoUser,
            FacebookUser,
            IEnumerable<ISocialInfoUser>,
            IEnumerable<FacebookUser>>
    {
        private readonly ISocialInfoUser _socialInfoUser;
        private readonly IFacebookDataHandler<FacebookUserRepository> _facebookDataHandler;
        
        public FacebookUserRepository( ISocialInfoUser socialInfoUser, IFacebookDataHandler<FacebookUserRepository> facebookDataHandler )
        {
            _socialInfoUser = socialInfoUser;
            _facebookDataHandler = facebookDataHandler;
        }

        public OperationResult<ISocialInfoUser> Get( ) =>
            _facebookDataHandler
                .Read<ISocialInfoUser,FacebookUser>( "me",
                    MapOut,
                    _socialInfoUser );

        public ISocialInfoUser MapOut( FacebookUser dto ) =>
            _socialInfoUser;

        public FacebookUser MapIn( ISocialInfoUser model ) { throw new System.NotImplementedException( ); }

        public IEnumerable<ISocialInfoUser> MapMany( IEnumerable<FacebookUser> dtoCollection ) { throw new System.NotImplementedException( ); }
    }
}