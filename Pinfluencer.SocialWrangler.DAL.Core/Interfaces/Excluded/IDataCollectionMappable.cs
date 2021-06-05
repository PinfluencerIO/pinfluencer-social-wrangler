namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded
{
    public interface IDataCollectionMappable<out TModelCollection, in TDtoCollection>
    {
        TModelCollection MapMany( TDtoCollection dtoCollection );
    }
}