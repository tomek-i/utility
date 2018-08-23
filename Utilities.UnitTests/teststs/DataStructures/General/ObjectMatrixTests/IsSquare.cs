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
    public class IsSquare:ObjectMatrixTest
    {
        [Test]
        public void Simple()
        {
            var matrix = new ObjectMatrix<int>(10, 15);
            Assert.IsFalse(matrix.IsSquare);

            matrix = new ObjectMatrix<int>(3, 3);
            Assert.IsTrue(matrix.IsSquare);

            matrix = new ObjectMatrix<int>(9, 9);
            Assert.IsTrue(matrix.IsSquare);

            matrix = new ObjectMatrix<int>(2, 3);
            Assert.IsFalse(matrix.IsSquare);
        }
    }
}