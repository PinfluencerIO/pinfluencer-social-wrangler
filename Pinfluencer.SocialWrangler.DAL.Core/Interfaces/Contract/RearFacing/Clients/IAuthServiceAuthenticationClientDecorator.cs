namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Contract.RearFacing.Clients
{
    public interface IAuthServiceAuthenticationClientDecorator
    {
        string GetToken( ( string clientId, string clientSecret, string audience ) authSettings );
    }
}