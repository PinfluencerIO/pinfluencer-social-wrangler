using System.Collections.Generic;
using System.Linq;
using Aidan.Common.Core;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.DAL.Core.Dtos.Dtos;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.FrontFacing.Social;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded;

namespace Pinfluencer.SocialWrangler.DAL.Facebook.Repositories
{
    public class InstagramContentRepository : IDataCollectionMappable<IEnumerable<Content>,DataArray<InstagramContent>>, ISocialContentRepository
    {
        private readonly IFacebookDataHandler<InstagramContentRepository> _facebookDataHandler;
        public InstagramContentRepository( IFacebookDataHandler<InstagramContentRepository> facebookDataHandler )
        {
            _facebookDataHandler = facebookDataHandler;
        }

        public ObjectResult<IEnumerable<Content>> GetAll( string user )
        {
            return _facebookDataHandler
                .Read<IEnumerable<Content>,DataArray<InstagramContent>>( $"{user}/media",
                    MapMany,
                    Enumerable.Empty<Content>( ) );
        }

        public IEnumerable<Content> MapMany( DataArray<InstagramContent> dtoCollection )
        {
            return dtoCollection
                .Data
                .Select( x => new Content
                {
                    Id = x.Id,
                    TimeOfUpload = x.UploadTime
                } );
        }
    }
}