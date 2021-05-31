namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers
{
    public interface IDataMappableIn<in TModel, out TDto>
    {
        TDto MapIn( TModel model );
    }
}