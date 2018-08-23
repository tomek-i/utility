﻿/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.EdgeTests
{
    [TestFixture]
        public class Weight
        {
            [Test]
            public void Simple()
            {
                var edge = new Edge<int>(new Vertex<int>(5), new Vertex<int>(4), 23.2, true);

                Assert.AreEqual(edge.Weight, 23.2);

                edge.Weight = 14.6;
                Assert.AreEqual(edge.Weight, 14.6);
            }
        }
}
