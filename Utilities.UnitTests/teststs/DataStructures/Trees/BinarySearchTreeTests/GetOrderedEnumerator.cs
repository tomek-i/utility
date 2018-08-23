/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests
{
    [TestFixture]
    public class GetOrderedEnumerator : BinarySearchTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = GetTestTree();
            var enumerator = tree.GetOrderedEnumerator();

            var list = new List<KeyValuePair<int, string>>();

            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Current);
            }

            Assert.AreEqual(1, list[0].Key);
            Assert.AreEqual("1", list[0].Value);
            Assert.AreEqual(2, list[1].Key);
            Assert.AreEqual("2", list[1].Value);
            Assert.AreEqual(4, list[2].Key);
            Assert.AreEqual("4", list[2].Value);
            Assert.AreEqual(5, list[3].Key);
            Assert.AreEqual("5", list[3].Value);
            Assert.AreEqual(6, list[4].Key);
            Assert.AreEqual("6", list[4].Value);
            Assert.AreEqual(19, list[5].Key);
            Assert.AreEqual("19", list[5].Value);

            Assert.AreEqual(list.Count, 6);
        }

    }
}