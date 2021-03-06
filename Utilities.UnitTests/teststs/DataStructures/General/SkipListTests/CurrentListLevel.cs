/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class CurrentListLevel
    {

        [Test]
        public void Simple()
        {
            var skipList = new SkipList<int, string>();
            Assert.AreEqual(skipList.CurrentListLevel, 0);

            for (var i = 0; i < 100; i++)
            {
                skipList.Add(new KeyValuePair<int, string>(i, i.ToString()));
            }

            Assert.Greater(skipList.CurrentListLevel, 0);
        }

    }
}