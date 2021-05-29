using System;
using System.Collections;
using System.Collections.Generic;
using Facebook;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Interfaces.Models;
using Pinfluencer.SocialWrangler.Core.Interfaces.Repositories;
using Pinfluencer.SocialWrangler.Core.Models.User;
using Pinfluencer.SocialWrangler.Crosscutting.Utils;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Clients;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Common;
using Pinfluencer.SocialWrangler.DAL.Common;
using Pinfluencer.SocialWrangler.DAL.Common.Dtos;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers;
using Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble;
using Influencer = Pinfluencer.SocialWrangler.DAL.Pinfluencer.Dtos.Bubble.Influencer;
using InfluencerModel = Pinfluencer.SocialWrangler.Core.Models.User.Influencer;

namespace Pinfluencer.SocialWrangler.DAL.Pinfluencer.Repositories
{
    //TODO: REFACTOR SEPERATE DATA SOURCES INTO SEPERATE REPOSITORIES
    //TODO: ADD LOGGING !!!
    public class UserRepository :
        IUserRepository,
        IDataMappable<User,
            TypeResponse<Profile>,
            IEnumerable<User>,
            TypeResponse<BubbleCollection<Profile>>>
    {
        private readonly Auth0Context _auth0Context;
        private readonly FacebookDecorator _facebookDecorator;
        private readonly IBubbleDataHandler<UserRepository> _bubbleDataHandler;
        private readonly ILoggerAdapter<UserRepository> _logger;

        public UserRepository( Auth0Context auth0Context,
            FacebookDecorator facebookDecorator,
            ILoggerAdapter<UserRepository> logger,
            IBubbleDataHandler<UserRepository> bubbleDataHandler )
        {
            _auth0Context = auth0Context;
            _facebookDecorator = facebookDecorator;
            _logger = logger;
            _bubbleDataHandler = bubbleDataHandler;
        }

        //TODO: dont swallow all exceptions
        public OperationResult<string> GetInstagramToken( string id )
        {
            try
            {
                var user = _auth0Context.GetUser( id );
                var result =
                    new OperationResult<string>( user.Identities[ 0 ].AccessToken, OperationResultEnum.Success );
                _logger.LogInfo( "instagram token fetched successfully" );
                return result;
            }
            catch( Exception )
            {
                _logger.LogError( "instagram token was not fetched" );
                return new OperationResult<string>( "", OperationResultEnum.Failed );
            }
        }

        //TODO: WRITE TESTS FOR SERIALIZATION AND SCHEMA ISSUES ( REGRESSION )
        public OperationResult<User> Get( string id ) =>
            _bubbleDataHandler.Read<User,TypeResponse<Profile>>( $"profile/{id}",
                MapOut,
                new User() );

        public User MapOut( TypeResponse<Profile> dto ) =>
            new User { Id = dto.Type.Id, Name = dto.Type.Name };

        public TypeResponse<Profile> MapIn( User model ) { throw new NotImplementedException( ); }

        public IEnumerable<User> MapMany( TypeResponse<BubbleCollection<Profile>> dtoCollection ) { throw new NotImplementedException( ); }
    }
}