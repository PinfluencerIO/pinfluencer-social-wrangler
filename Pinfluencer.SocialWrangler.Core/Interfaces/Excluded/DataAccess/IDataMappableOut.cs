namespace Pinfluencer.SocialWrangler.Core.Interfaces.Excluded.DataAccess
{
    public interface IDataMappableOut<out TModel, in TDto>
    {
        TModel MapOut( TDto dto );
    }
}