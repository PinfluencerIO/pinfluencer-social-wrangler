namespace Pinfluencer.SocialWrangler.DAL.Core.Interfaces.Handlers
{
    public interface IDataMappableOut<out TModel, in TDto>
    {
        TModel MapOut( TDto dto );
    }
}