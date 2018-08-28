using System.Collections.Generic;

namespace TI.Utilities
{
    public abstract class GenericMapper<TKey,TObject> : IGenericMapper<TKey, TObject>
    {
        protected readonly IDictionary<TKey, TObject> mappings;

        public GenericMapper()
        {
            mappings = new Dictionary<TKey, TObject>();
        }
        public virtual void Map(TKey key, TObject obj)
        {
            if (mappings.ContainsKey(key))
                mappings[key] = obj;
            else
                mappings.Add(key, obj);
        }

        public virtual TObject Get(TKey key)
        {
            return mappings.ContainsKey(key) ? mappings[key] : default(TObject);
        }

        public virtual void Remove(TKey key)
        {

            if (mappings.ContainsKey(key))
            {
                mappings.Remove(key);
            }
        }

        public virtual void Clear()
        {
            mappings.Clear();
        }
    }
}