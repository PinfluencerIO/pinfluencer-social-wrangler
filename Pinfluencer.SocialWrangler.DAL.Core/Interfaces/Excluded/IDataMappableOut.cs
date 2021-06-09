namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Excluded
{
    public interface IDataMappableOut<out TModel, in TDto>
    {
        TModel MapOut( TDto dto );
    }
}