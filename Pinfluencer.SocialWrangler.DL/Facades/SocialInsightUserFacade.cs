using System.Collections.Generic;
using System.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Social;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;
using Pinfluencer.SocialWrangler.DL.Core.Interfaces.Contract;

namespace Pinfluencer.SocialWrangler.DL.Facades
{
    public class SocialInsightUserFacade : ISocialInsightUserFacade
    {
        private readonly IInsightsSocialUserRepository _insightsSocialUserRepository;

        public SocialInsightUserFacade( IInsightsSocialUserRepository insightsSocialUserRepository )
        {
            _insightsSocialUserRepository = insightsSocialUserRepository;
        }

        public ObjectResult<IEnumerable<SocialInsightsUser>> GetUsers( )
        {
            var result = _insightsSocialUserRepository.GetAll( );
            if( !result.Value.Any( ) )
            {
                return new ObjectResult<IEnumerable<SocialInsightsUser>>
                {
                    Status = OperationResultEnum.Failed,
                    Value = result.Value
                };
            }

            return result;
        }

        public ObjectResult<SocialInsightsUser> GetFirstUser( )
        {
            var usersResult = GetUsers( );
            if( usersResult.Status == OperationResultEnum.Failed )
            {
                return new ObjectResult<SocialInsightsUser>
                {
                    Status = OperationResultEnum.Failed,
                    Value = null
                };
            }
            return new ObjectResult<SocialInsightsUser>
            {
                Status = OperationResultEnum.Success,
                Value = usersResult
                    .Value
                    .First( )
            };
        }
    }
}