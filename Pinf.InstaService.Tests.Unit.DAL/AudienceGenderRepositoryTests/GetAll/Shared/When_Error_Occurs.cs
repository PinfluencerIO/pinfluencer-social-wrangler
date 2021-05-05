using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Pinf.InstaService.Core;
using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Models.Insights;

namespace Pinf.InstaService.Tests.Unit.DAL.AudienceGenderRepositoryTests.GetAll.Shared
{
    public abstract class When_Error_Occurs : When_Called
    {
        protected OperationResult<IEnumerable<AudiencePercentage<GenderEnum>>> Result;

        [ Test ]
        public void Then_Failiure_Is_Returned( ) { Assert.AreEqual( OperationResultEnum.Failed, Result ); }
        
        [ Test ]
        public void Then_Error_Is_Logged( )
        {
            MockLogger
                .Received( )
                .LogError( Arg.Any<string>( ) );
        }
    }
}