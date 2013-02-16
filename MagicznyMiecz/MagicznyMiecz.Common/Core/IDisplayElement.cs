namespace MagicznyMiecz.Common.Core
{
    public interface IDisplayElement<out TElement>
    {
        TElement this[string key] { get; }
    }
}