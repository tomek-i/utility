/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests
{
    [TestFixture]
    public class Clear : BinarySearchTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = new BinarySearchTree<int, string>();
            tree.Clear();

            Assert.AreEqual(tree.Count, 0);

            tree = GetTestTree();
            Assert.IsTrue(tree.ContainsKey(19));

            tree.Clear();
            Assert.AreEqual(tree.Count, 0);
            Assert.IsFalse(tree.ContainsKey(19));
        }

    }
}