/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class Contains:ObjectMatrixTest
    {
        [Test]
        public void Simple()
        {
            var matrix = new ObjectMatrix<int>(10, 15);

            matrix[5, 5] = 13;

            Assert.IsTrue(matrix.Contains(13));
            Assert.IsFalse(matrix.Contains(15));

            matrix[2, 3] = 15;

            Assert.IsTrue(matrix.Contains(13));
            Assert.IsTrue(matrix.Contains(15));
            Assert.IsFalse(matrix.Contains(17));
        }
    }
}