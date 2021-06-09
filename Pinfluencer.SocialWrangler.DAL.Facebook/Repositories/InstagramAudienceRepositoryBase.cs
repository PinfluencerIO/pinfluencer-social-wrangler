using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Core.Dtos.Dtos;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Repositories
{
    public abstract class InstagramAudienceRepositoryBase<TRepository, TProperty> :
        IDataCollectionMappable<IEnumerable<AudienceCount<TProperty>>,
            DataArray<Metric<object>>>
    {
        protected readonly IFacebookDataHandler<TRepository> FacebookDataHandler;

        protected InstagramAudienceRepositoryBase( IFacebookDataHandler<TRepository> facebookDataHandler )
        {
            FacebookDataHandler = facebookDataHandler;
        }

        public abstract IEnumerable<AudienceCount<TProperty>> MapMany( DataArray<Metric<object>> dtoCollection );

        public abstract ObjectResult<IEnumerable<AudienceCount<TProperty>>> Get( string instaId );
    }
}