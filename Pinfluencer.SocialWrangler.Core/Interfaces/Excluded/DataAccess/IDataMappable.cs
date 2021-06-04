using Pinfluencer.SocialWrangler.Core.Interfaces.Contract.DataAccessLayer.RearFacing.Handlers;

namespace Pinfluencer.SocialWrangler.Core.Interfaces.Excluded.DataAccess
{
    public interface IDataMappable<TModel, TDto> : IDataMappableOut<TModel, TDto>, IDataMappableIn<TModel, TDto>
    {
    }
}