/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.LUDecompositionTests
{
    [TestFixture]
    public class LowerTriangularFactor
    {

        [Test]
        public void Simple()
        {
            var matrix = new Matrix(3, 3);

            /*
            A = [ 1    2    3
                  4    5    6
                  7    8    0 ];
             
            L =
                1.0000         0         0
                0.1429    1.0000         0
                0.5714    0.5000    1.0000  
             
            U =
                7.0000    8.0000         0
                     0    0.8571    3.0000
                     0         0    4.5000 
            */

            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[1, 0] = 4;
            matrix[1, 1] = 5;
            matrix[1, 2] = 6;
            matrix[2, 0] = 7;
            matrix[2, 1] = 8;
            matrix[2, 2] = 0;

            var decomposition = new LUDecomposition(matrix);

            var L = decomposition.LeftFactorMatrix;

            Assert.AreEqual(L[0, 0], 1.000, 0.0001);
            Assert.AreEqual(L[0, 1], 0.000, 0.0001);
            Assert.AreEqual(L[0, 2], 0.000, 0.0001);

            Assert.AreEqual(L[1, 0], 0.1429, 0.0001);
            Assert.AreEqual(L[1, 1], 1.0000, 0.0001);
            Assert.AreEqual(L[1, 2], 0.0000, 0.0001);

            Assert.AreEqual(L[2, 0], 0.5714, 0.0001);
            Assert.AreEqual(L[2, 1], 0.5000, 0.0001);
            Assert.AreEqual(L[2, 2], 1.000, 0.0001);
        }

    }
}