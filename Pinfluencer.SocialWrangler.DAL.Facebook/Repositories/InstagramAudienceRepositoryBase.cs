using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.Core.Interfaces.Excluded.DataAccess;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Facebook.Dtos;

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

        public abstract OperationResult<IEnumerable<AudienceCount<TProperty>>> Get( string instaId );
    }
}