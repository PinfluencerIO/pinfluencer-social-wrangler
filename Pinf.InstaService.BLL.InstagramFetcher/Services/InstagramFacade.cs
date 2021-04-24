﻿using System.Linq;
using Pinf.InstaService.BLL.Core;
using Pinf.InstaService.BLL.Core.Enum;
using Pinf.InstaService.BLL.Core.Repositories;
using Pinf.InstaService.BLL.Models.Insights;
using Pinf.InstaService.BLL.Models.InstaUser;

namespace Pinf.InstaService.BLL.InstagramFetcher.Services
{
    public class InstagramFacade
    {
        private readonly IInstaImpressionsRepository _impressionsRepository;
        private readonly IInstaUserRepository _instaUserRepository;

        public InstagramFacade(
            IInstaImpressionsRepository impressionsRepository, IInstaUserRepository instaUserRepository )
        {
            _impressionsRepository = impressionsRepository;
            _instaUserRepository = instaUserRepository;
        }

        public OperationResult<InstaInsightsCollection> GetUserInsights( string id )
        {
            var impressions = _impressionsRepository.GetImpressions( id );
            if( impressions.Status == OperationResultEnum.Success )
                return new OperationResult<InstaInsightsCollection>( new InstaInsightsCollection( impressions.Value ),
                    OperationResultEnum.Success );
            return new OperationResult<InstaInsightsCollection>( new InstaInsightsCollection(
                Enumerable.Empty<InstaImpression>( )
            ), OperationResultEnum.Failed );
        }
        
        public OperationResult<InstaUserIdentityCollection> GetUsers( )
        {
            var users = _instaUserRepository.GetUsers( );

            return new OperationResult<InstaUserIdentityCollection>(
                new InstaUserIdentityCollection(
                    users.Value.Select( x => x.Identity ),
                    users.Value.Count( ) > 1,
                    !users.Value.Any( )
                ),
                users.Status
            );
        }
    }
}