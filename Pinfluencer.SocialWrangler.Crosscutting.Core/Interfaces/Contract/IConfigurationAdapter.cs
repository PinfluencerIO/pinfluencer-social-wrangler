namespace Pinfluencer.SocialWrangler.Crosscutting.Core.Interfaces.Contract
{
    public interface IConfigurationAdapter
    {
        T Get<T>( );
    }
}