/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System.Collections.Generic;
using NGenerics.DataStructures.Trees;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.Patterns.Visitor.KeyTrackingVisitorTests
{
    [TestFixture]
    public class Visit
    {
        [Test]
        public void Simple()
        {
            var tree = new RedBlackTree<int, string>();

            for (var i = 0; i < 50; i++)
            {
                tree.Add(i, i.ToString());
            }

            var visitor = new KeyTrackingVisitor<int, string>();
            tree.AcceptVisitor(visitor);

            Assert.IsFalse(visitor.HasCompleted);

            Assert.AreEqual(visitor.TrackingList.Count, 50);

            var list = new List<int>(visitor.TrackingList);

            for (var i = 0; i < 50; i++)
            {
                Assert.IsTrue(list.Contains(i));
            }
        }
    }

}