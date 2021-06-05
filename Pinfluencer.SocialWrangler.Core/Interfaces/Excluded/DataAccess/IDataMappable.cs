namespace Pinfluencer.SocialWrangler.Core.Interfaces.Excluded.DataAccess
{
    public interface IDataMappable<TModel, TDto> : IDataMappableOut<TModel, TDto>, IDataMappableIn<TModel, TDto>
    {
    }
}