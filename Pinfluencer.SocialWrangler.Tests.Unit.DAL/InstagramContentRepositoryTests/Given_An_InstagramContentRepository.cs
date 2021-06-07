using System.Collections.Generic;
using System.Linq;
using Pinfluencer.SocialWrangler.Core;
using Pinfluencer.SocialWrangler.Core.Enum;
using Pinfluencer.SocialWrangler.Core.Models.Insights;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Core.Dtos.Dtos;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.InstagramContentRepositoryTests
{
    public class Given_An_InstagramContentRepository : DataGivenWhenThen<InstagramContentRepository>
    {
        protected override void Given( )
        {
            base.Given( );
            SUT = new InstagramContentRepository( MockFacebookDataHandler );
        }
    }

    public class InstagramContentRepository : IDataCollectionMappable<IEnumerable<Content>,DataArray<InstagramContent>>
    {
        private readonly IFacebookDataHandler<InstagramContentRepository> _facebookDataHandler;
        public InstagramContentRepository( IFacebookDataHandler<InstagramContentRepository> facebookDataHandler )
        {
            _facebookDataHandler = facebookDataHandler;
        }

        public ObjectResult<IEnumerable<Content>> GetAll( string user )
        {
            return new ObjectResult<IEnumerable<Content>>
            {
                Status = OperationResultEnum.Failed,
                Value = Enumerable.Empty<Content>( )
            };
        }

        public IEnumerable<Content> MapMany( DataArray<InstagramContent> dtoCollection )
        {
            return Enumerable.Empty<Content>( );
        }
    }
}