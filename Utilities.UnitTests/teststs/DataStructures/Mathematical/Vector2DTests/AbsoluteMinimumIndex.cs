/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class AbsoluteMinimumIndex
    {

        [Test]
        public void Simple()
        {
            var vector1 = new Vector2D(1, -4);

            Assert.AreEqual(0, vector1.AbsoluteMinimumIndex());

            Assert.AreEqual(1, vector1.X);
            Assert.AreEqual(-4, vector1.Y);


            var vector2 = new Vector2D(-4, 1);

            Assert.AreEqual(1, vector2.AbsoluteMinimumIndex());

            Assert.AreEqual(-4, vector2.X);
            Assert.AreEqual(1, vector2.Y);
        }

    }
}