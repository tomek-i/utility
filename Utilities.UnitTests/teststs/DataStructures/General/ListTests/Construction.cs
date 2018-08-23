/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void Simple()
        {
            var listBase = new ListBase<int>();
				
        }
        [Test]
        public void Capacity()
        {
            var listBase = new ListBase<int>(3);
            Assert.AreEqual(3, listBase.Capacity);
        }
        [Test]
        public void Collection()
        {
            var listBase = new ListBase<int>(new[]{3});
            Assert.IsTrue(listBase.Contains(3));
        }
    }
}