/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections.Generic;
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.DequeTests
{
    [TestFixture]
    public class Contruction : DequeTest
    {

        [Test]
        public void Simple()
        {
            var deque = new Deque<int>();
            Assert.AreEqual(deque.Count, 0);
            Assert.IsTrue(deque.IsEmpty);

            var stack = new Stack<int>();

            for (var i = 0; i < 3; i++)
            {
                stack.Push(i * 4);
            }

            deque = new Deque<int>(stack);

            for (var i = 2; i >= 0; i--)
            {
                Assert.AreEqual(deque.DequeueHead(), i * 4);
            }
        }

    }
}