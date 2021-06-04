namespace Pinfluencer.SocialWrangler.Core.Interfaces.Excluded.DataAccess
{
    public interface IDataMappableIn<in TModel, out TDto>
    {
        TDto MapIn( TModel model );
    }
}