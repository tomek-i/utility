/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.DequeTests
{

    public class DequeTest
    {

        internal static void TestIfSame(Deque<int> deque, Deque<int> newDeque)
        {
            while (deque.Count > 0)
            {
                Assert.AreEqual(deque.DequeueHead(), newDeque.DequeueHead());
            }

            Assert.AreEqual(newDeque.Count, 0);
        }

        internal static Deque<int> GetTestDeque()
        {
            var test = new Deque<int>();

            for (var i = 0; i < 5; i++)
            {
                test.EnqueueHead(i * 3);
            }

            return test;
        }

    }
}
