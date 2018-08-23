/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class Normalize
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(3);
            vector[0] = 23;
            vector[1] = -21;
            vector[2] = 4;
            vector.Normalize();
            Assert.AreEqual(1, vector.Magnitude());
        }

    }
}