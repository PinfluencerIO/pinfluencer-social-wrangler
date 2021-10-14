using Aidan.Common.Core;

namespace Pinfluencer.SocialWrangler.Core.Interfaces
{
    public interface IGenericInitializable<in T>
    {
        public Result Initialize( T parameters );
    }
}