/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class AbsoluteMaximum
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector3D(1, -4, 3);
            Assert.AreEqual(4, vector.AbsoluteMaximum());
            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(-4, vector.Y);
            Assert.AreEqual(3, vector.Z);
        }

    }
}