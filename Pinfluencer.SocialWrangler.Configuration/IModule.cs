using Microsoft.Extensions.DependencyInjection;

namespace Pinfluencer.SocialWrangler.Configuration
{
    public interface IModule
    {
        IServiceCollection Bind( IServiceCollection services );
    }
}