using System.Collections;

namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers
{
    public interface IDataMappable<TModel, TDto, TModelCollection, TDtoCollection>
    {
        TModel MapOut( TDto dto );
        TDto MapIn( TModel model );

        TModelCollection MapMany( TDtoCollection dtoCollection );
    }
}