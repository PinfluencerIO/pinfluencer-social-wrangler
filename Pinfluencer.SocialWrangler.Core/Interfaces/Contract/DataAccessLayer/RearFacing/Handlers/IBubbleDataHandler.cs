using Pinfluencer.SocialWrangler.Core.Interfaces.Excluded.DataAccess;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Handlers
{
    public interface IBubbleDataHandler<T> : ICreateable, IReadable, IUpdatable
    {
    }
}