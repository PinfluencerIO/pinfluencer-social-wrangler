using System.Collections;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers
{
    public interface IDataMappable<TModel, TDto> : IDataMappableOut<TModel, TDto>, IDataMappableIn<TModel, TDto>
    {
    }
}