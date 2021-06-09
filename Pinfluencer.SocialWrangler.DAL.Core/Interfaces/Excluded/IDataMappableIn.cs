namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded
{
    public interface IDataMappableIn<in TModel, out TDto>
    {
        TDto MapIn( TModel model );
    }
}