using System.Collections;
using System.Collections.Generic;
using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Handlers;
using Pinfluencer.SocialWrangler.Core.Interfaces.Excluded.DataAccess;
using Pinfluencer.SocialWrangler.Crosscutting.NUnit.PinfluencerExtensions;
using Pinfluencer.SocialWrangler.DAL.Common.Handlers;

namespace Pinfluencer.SocialWrangler.Tests.Unit.DAL.Common.FacebookDataHandlerTests
{
    public abstract class Given_A_FacebookDataHandler : DataGivenWhenThen<object>, IDataMappable<Model,Dto>
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
    }
}