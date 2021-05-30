using System.Collections;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers
{
    public interface IDataCollectionMappable<out TModelCollection, in TDtoCollection>
    {
        TModelCollection MapMany( TDtoCollection dtoCollection );
    }

    public interface IDataMappable<TModel, TDto>
    {
        TModel MapOut( TDto dto );
        TDto MapIn( TModel model );
    }
}