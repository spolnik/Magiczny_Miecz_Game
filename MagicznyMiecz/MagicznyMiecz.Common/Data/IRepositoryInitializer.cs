namespace MagicznyMiecz.Common.Data
{
    public interface IRepositoryInitializer<out TElement>
    {
        void Init(IEditableRepository<TElement> repository);
    }
}