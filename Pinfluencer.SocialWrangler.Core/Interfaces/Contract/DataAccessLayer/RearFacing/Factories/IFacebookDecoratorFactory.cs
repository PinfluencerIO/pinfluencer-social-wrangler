namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Factories
{
    public interface IFacebookDecoratorFactory : IFactory
    {
        IFacebookDecorator Factory( string token );
    }
}