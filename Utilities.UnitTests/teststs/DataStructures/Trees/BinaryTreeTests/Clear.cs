/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class Clear : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = new BinaryTree<int>(5);
            binaryTree.Clear();

            Assert.AreEqual(binaryTree.Count, 0);
            Assert.IsTrue(binaryTree.IsEmpty);

            binaryTree = GetTestTree();
            binaryTree.Clear();

            Assert.AreEqual(binaryTree.Count, 0);
            Assert.IsTrue(binaryTree.IsEmpty);
        }

    }
}