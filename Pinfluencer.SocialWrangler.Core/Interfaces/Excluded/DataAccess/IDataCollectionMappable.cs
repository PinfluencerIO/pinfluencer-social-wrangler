namespace Pinfluencer.SocialWrangler.Core.Interfaces.Excluded.DataAccess
{
    public interface IDataCollectionMappable<out TModelCollection, in TDtoCollection>
    {
        TModelCollection MapMany( TDtoCollection dtoCollection );
    }
}