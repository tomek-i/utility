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
    public class IsEmpty
    {

        [Test]
        public void Simple()
        {
            var pascalSet = new PascalSet(0, 500);
            Assert.IsTrue(pascalSet.IsEmpty);

            pascalSet.Add(50);
            Assert.IsFalse(pascalSet.IsEmpty);

            pascalSet.Add(100);
            Assert.IsFalse(pascalSet.IsEmpty);

            pascalSet.Clear();
            Assert.IsTrue(pascalSet.IsEmpty);
        }

    }
}