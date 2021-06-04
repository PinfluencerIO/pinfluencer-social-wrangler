namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing
{
    public interface ITokenRepository
    {
        OperationResult<string> Get( string authId );
    }
}