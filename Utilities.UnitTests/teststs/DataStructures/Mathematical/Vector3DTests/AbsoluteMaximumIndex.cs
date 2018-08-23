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
    public class AbsoluteMaximumIndex
    {

        [Test]
        public void Simple()
        {
            var vector1 = new Vector3D(1, -4, 3);
            Assert.AreEqual(1, vector1.AbsoluteMaximumIndex());
            Assert.AreEqual(1, vector1.X);
            Assert.AreEqual(-4, vector1.Y);
            Assert.AreEqual(3, vector1.Z);


            var vector2 = new Vector3D(1, -4, 5);
            Assert.AreEqual(2, vector2.AbsoluteMaximumIndex());
            Assert.AreEqual(1, vector2.X);
            Assert.AreEqual(-4, vector2.Y);
            Assert.AreEqual(5, vector2.Z);


            var vector3 = new Vector3D(7, -4, 3);
            Assert.AreEqual(0, vector3.AbsoluteMaximumIndex());
            Assert.AreEqual(7, vector3.X);
            Assert.AreEqual(-4, vector3.Y);
            Assert.AreEqual(3, vector3.Z);


            var vector4 = new Vector3D(7, -4, 8);
            Assert.AreEqual(2, vector4.AbsoluteMaximumIndex());
            Assert.AreEqual(7, vector4.X);
            Assert.AreEqual(-4, vector4.Y);
            Assert.AreEqual(8, vector4.Z);
        }

    }
}