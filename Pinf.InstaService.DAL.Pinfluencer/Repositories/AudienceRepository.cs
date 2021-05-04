using Pinf.InstaService.Core.Enum;
using Pinf.InstaService.Core.Interfaces.Clients;
using Pinf.InstaService.Core.Interfaces.Repositories;
using AudienceModel = Pinf.InstaService.Core.Models.Audience;
using Pinf.InstaService.Crosscutting.Utils;
using Pinf.InstaService.DAL.Pinfluencer.Dtos.Bubble;

namespace Pinf.InstaService.DAL.Pinfluencer.Repositories
{
    public class AudienceRepository : BubbleRepository<AudienceRepository>, IAudienceRepository
    {
        public AudienceRepository( IBubbleClient bubbleClient, ILoggerAdapter<AudienceRepository> logger ) : base( bubbleClient, logger )
        {
        }
        
        public OperationResultEnum Create( AudienceModel audience )
        {
            var (validRequest, httpStatusCode ) =
                ValidateRequestException( ( ) => BubbleClient.Post( "audience", new Audience(  ) ) );
            if( validRequest )
                if( ValidateHttpCode( httpStatusCode ) )
                {
                    Logger.LogInfo( "audience was created successfully" );
                    return OperationResultEnum.Success;
                }
            Logger.LogError( "audience was not created" );
            return OperationResultEnum.Failed;
        }

        public OperationResultEnum Update( AudienceModel audience )
        {
            throw new System.NotImplementedException( );
        }
    }
}