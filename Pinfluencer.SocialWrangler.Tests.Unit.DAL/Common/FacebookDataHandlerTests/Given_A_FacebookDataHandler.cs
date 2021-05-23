using System.Collections;
using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Common.Handlers;
using Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.FacebookDataHandlerTests
{
    public abstract class Given_A_FacebookDataHandler : DataGivenWhenThen<object>, IDataMappable<Model,Dto,IEnumerable<Model>,IEnumerable<Dto>>
    {
        protected FacebookDataHandler<object> FacebookSut;

        protected override void Given( )
        {
            base.Given( );
            FacebookSut = new FacebookDataHandler<object>( FacebookDecorator, MockLogger );
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

        public IEnumerable<Model> MapMany( IEnumerable<Dto> dtoCollection ) { throw new System.NotImplementedException( ); }
    }
}