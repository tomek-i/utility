namespace TI.Utilities
{
    public interface IGenericMapper<TKey, TObject>
    {
        void Clear();
        TObject Get(TKey key);
        void Map(TKey key, TObject obj);
        void Remove(TKey key);
    }
}