using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        private readonly IInstaAudienceInsightsRepository _instaAudienceInsightsRepository;

        public InstagramFacade(
            IInstaImpressionsRepository impressionsRepository, IInstaUserRepository instaUserRepository, IInstaAudienceInsightsRepository instaAudienceInsightsRepository )
        {
            _impressionsRepository = impressionsRepository;
            _instaUserRepository = instaUserRepository;
            _instaAudienceInsightsRepository = instaAudienceInsightsRepository;
        }

        public OperationResult<IEnumerable<ProfileViewsInsight>> GetMonthlyProfileViews( string id ) => _impressionsRepository.GetImpressions( id );

        //TODO: MOVE BUSINESS RULES OUT OF DATA LAYER ( NUMBER OF USERS RETURNED SHOULDN'T CONCERN DATA LAYER )
        public OperationResult<IEnumerable<InstaUser>> GetUsers( ) => _instaUserRepository.GetAll( );

        public OperationResult<IEnumerable<AudiencePercentage<CountryProperty>>> GetAudienceCountryInsights( string id )
        {
            throw new NotImplementedException( );
        }

        public OperationResult<IEnumerable<AudiencePercentage<GenderEnum>>> GetAudienceGenderInsights( string id )
        {
            throw new NotImplementedException( );
        }
        
        public OperationResult<IEnumerable<AudiencePercentage<AgeProperty>>> GetAudienceAgeInsights( string id )
        {
            throw new NotImplementedException( );
        }
    }
}