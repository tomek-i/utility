/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MaxPriorityQueueHeapTests
{
    [TestFixture]
    public class AddPriorityGroup : MaxPriorityQueueTest
    {

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullList()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Maximum);

            priorityQueue.AddPriorityGroup(null, 4);
        }

        [Test]
        public void Simple()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Maximum);

            var stringValues = new[] { "a", "b", "c", "d" };
            priorityQueue.AddPriorityGroup(stringValues, 4);

            stringValues = new[] { "e", "f", "g", "h" };
            priorityQueue.AddPriorityGroup(stringValues, 2);

            int priority;

            Assert.AreEqual(priorityQueue.Dequeue(out priority), "a");
            Assert.AreEqual(priority, 4);

            Assert.AreEqual(priorityQueue.Dequeue(out priority), "b");
            Assert.AreEqual(priority, 4);

            Assert.AreEqual(priorityQueue.Dequeue(out priority), "c");
            Assert.AreEqual(priority, 4);

            Assert.AreEqual(priorityQueue.Dequeue(out priority), "d");
            Assert.AreEqual(priority, 4);

            Assert.AreEqual(priorityQueue.Dequeue(out priority), "e");
            Assert.AreEqual(priority, 2);

            Assert.AreEqual(priorityQueue.Dequeue(out priority), "f");
            Assert.AreEqual(priority, 2);

            Assert.AreEqual(priorityQueue.Dequeue(out priority), "g");
            Assert.AreEqual(priority, 2);

            Assert.AreEqual(priorityQueue.Dequeue(out priority), "h");
            Assert.AreEqual(priority, 2);
        }

    }
}