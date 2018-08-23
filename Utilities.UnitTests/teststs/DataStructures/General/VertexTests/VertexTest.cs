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

namespace NGenerics.Tests.DataStructures.General.VertexTests
{
  
    public class VertexTest
    {   

        internal static void AssertContainsEdges(ICollection<Edge<int>> edgeList, bool containsValue, params Edge<int>[] edges)
        {
            foreach (var edge in edges)
            {
                Assert.AreEqual(edgeList.Contains(edge), containsValue);
            }
        }

    }
}
