/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MinHeapTests
{
    [TestFixture]
    public class Add : MinHeapTest
    {
        [Test]
        public void Simple()
        {
            var heap = new Heap<int>(HeapType.Minimum)
                           {
                               5
                           };

            Assert.AreEqual(heap.Count, 1);
            Assert.IsFalse(heap.IsEmpty);
            Assert.AreEqual(heap.Root, 5);

            heap.Add(2);
            Assert.AreEqual(heap.Count, 2);
            Assert.IsFalse(heap.IsEmpty);
            Assert.AreEqual(heap.Root, 2);

            heap.Add(3);
            Assert.AreEqual(heap.Count, 3);
            Assert.IsFalse(heap.IsEmpty);
            Assert.AreEqual(heap.Root, 2);

            Assert.AreEqual(heap.RemoveRoot(), 2);

            heap.Add(1);
            Assert.AreEqual(heap.Count, 3);
            Assert.IsFalse(heap.IsEmpty);
            Assert.AreEqual(heap.Root, 1);
        }
    }
}