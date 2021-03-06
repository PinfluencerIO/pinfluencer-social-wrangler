using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Common.Handlers;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.FacebookDataHandlerTests
{
    public abstract class Given_A_FacebookDataHandler : DataGivenWhenThen<object>, IDataMappable<Model, Dto>
    {
        protected FacebookDataHandler<object> FacebookSut;

        public Model MapOut( Dto dto )
        {
            return new Model
            {
                Id = dto.Id,
                Value = dto.Value
            };
        }

        public Dto MapIn( Model model )
        {
            return new Dto
            {
                Id = model.Id,
                Value = model.Value
            };
        }

        protected override void Given( )
        {
            base.Given( );
            FacebookSut = new FacebookDataHandler<object>( MockFacebookDecorator, MockLogger );
        }
    }
}