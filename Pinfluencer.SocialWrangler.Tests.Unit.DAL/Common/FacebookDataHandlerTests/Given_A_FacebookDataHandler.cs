using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Common.Handlers;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.FacebookDataHandlerTests
{
    public class Given_A_FacebookDataHandler : DataGivenWhenThen<FacebookDataHandler<object>>, IDataMappable<Model,Dto>
    {
        protected override void Given( )
        {
            base.Given( );
            SUT = new FacebookDataHandler<object>( FacebookDecorator );
        }

        public Model MapOut( Dto dto ) =>
            new Model
            {
                Id = dto.Id,
                Value = dto.Value
            };

        public Dto MapIn( Model model ) =>
            new Dto
            {
                Id = model.Id,
                Value = model.Value
            };
    }
}