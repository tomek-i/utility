/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SetTests
{
    [TestFixture]
    public class Capacity
    {

        [Test]
        public void Simple()
        {
            var pascalSet = new PascalSet(100);
            Assert.AreEqual(pascalSet.Capacity, 101);

            pascalSet = new PascalSet(1, 100);
            Assert.AreEqual(pascalSet.Capacity, 100);

            pascalSet = new PascalSet(55, 100);
            Assert.AreEqual(pascalSet.Capacity, 46);
        }

    }
}