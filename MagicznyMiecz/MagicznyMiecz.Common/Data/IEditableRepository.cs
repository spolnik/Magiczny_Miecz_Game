namespace MagicznyMiecz.Common.Data
{
    public interface IEditableRepository<in TElement>
    {
        void Add(TElement card);
        void Init();
    }
}