namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded
{
    public interface IDataCollectionMappable<out TModelCollection, in TDtoCollection>
    {
        public TModelCollection MapMany( TDtoCollection dtoCollection );
    }
}