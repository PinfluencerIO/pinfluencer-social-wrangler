using System.Collections.Generic;
using System.Linq;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Repositories;
using Pinf.InstaService.Core.Models.Insights;
using Pinf.InstaService.Core.Models.InstaUser;

namespace Pinf.InstaService.BLL.Facades
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

        public OperationResult<IEnumerable<InstaProfileImpressionsInsight>> GetUserInsights( string id )
        {
            var impressions = _impressionsRepository.GetImpressions( id );
            if( impressions.Status == OperationResultEnum.Success )
                return new OperationResult<IEnumerable<InstaProfileImpressionsInsight>>( impressions.Value, OperationResultEnum.Success );
            return new OperationResult<IEnumerable<InstaProfileImpressionsInsight>>( Enumerable.Empty<InstaProfileImpressionsInsight>( ), OperationResultEnum.Failed );
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