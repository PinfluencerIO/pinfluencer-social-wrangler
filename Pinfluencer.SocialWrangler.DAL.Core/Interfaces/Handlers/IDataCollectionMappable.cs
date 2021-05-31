namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers
{
    public interface IDataCollectionMappable<out TModelCollection, in TDtoCollection>
    {
        TModelCollection MapMany( TDtoCollection dtoCollection );
    }
}