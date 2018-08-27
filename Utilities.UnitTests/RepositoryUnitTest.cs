using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TI.Utilities.UnitTests
{

    public class TestMemoryRepository : Repository.Repository<int>
    {
        private List<int> inMemory = new List<int>();

        public override IReadOnlyCollection<int> All()
        {
            return new ReadOnlyCollection(inMemory);
        }

        public override bool Contains(int item)
        {
            inMemory.Contains(item);
        }

        public override int First()
        {
           return  inMemory.First();
        }

        public override int Last()
        {
            return inMemory.Last();
        }

        public override IEnumerable<int> Where(Expression<Func<int, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<int> Where(Func<int, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
    class RepositoryUnitTest
    {

        public RepositoryUnitTest()
        {
            TestMemoryRepository repo = new TestMemoryRepository();
            
            //TODO: test repository (in memory)
            // test also with database (in memory database for lower overhead)

        }
    }
}
