namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded
{
    public interface IDataMappable<TModel, TDto> : IDataMappableOut<TModel, TDto>, IDataMappableIn<TModel, TDto>
    {
    }
}