/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MaxHeapTests
{
    [TestFixture]
    public class CopyTo : MaxHeapTest
    {
        [Test]
        public void Simple()
        {
            var heap = GetTestHeap();
            var array = new int[heap.Count];

            heap.CopyTo(array, 0);

            var list = new List<int>(array);
            Assert.AreEqual(list.Count, heap.Count);
            Assert.IsTrue(list.Contains(5));
            Assert.IsTrue(list.Contains(4));
            Assert.IsTrue(list.Contains(99));
            Assert.IsTrue(list.Contains(12));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullArray()
        {
            var heap = GetTestHeap();
            heap.CopyTo(null, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceoptionInvalid1()
        {
            var heap = GetTestHeap();
            var array = new int[heap.Count - 1];
            heap.CopyTo(array, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalid2()
        {
            var heap = GetTestHeap();
            var array = new int[heap.Count];
            heap.CopyTo(array, 1);
        }
    }
}