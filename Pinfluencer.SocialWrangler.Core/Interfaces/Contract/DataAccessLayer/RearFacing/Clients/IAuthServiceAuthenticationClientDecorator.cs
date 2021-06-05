namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Clients
{
    public interface IAuthServiceAuthenticationClientDecorator
    {
        string GetToken( ( string clientId, string clientSecret, string audience ) authSettings );
    }
}