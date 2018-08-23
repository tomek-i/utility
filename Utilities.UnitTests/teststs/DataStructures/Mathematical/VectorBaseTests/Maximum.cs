/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorBaseTests
{
    [TestFixture]
    public class Maximum
    {
        [Test]
        public void Simple()
        {
            var vector = new VectorN(3);
            vector.SetValues(1, -4, 3);

            Assert.AreEqual(3, vector.Maximum());
            Assert.AreEqual(1, vector[0]);
            Assert.AreEqual(-4, vector[1]);
            Assert.AreEqual(3, vector[2]);
        }
    }
}