namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers
{
    public interface IDataMappable<TModel, TDto>
    {
        TModel MapOut( TDto dto );
        TDto MapIn( TModel model );
    }
}