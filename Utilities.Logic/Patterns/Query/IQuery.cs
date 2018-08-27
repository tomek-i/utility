using System.Linq;

namespace TI.Utilities.Patterns.Query
{
    public interface IQuery<T>
    {
        IQueryable<T> Filter(IQueryable<T> items);
    }
}
