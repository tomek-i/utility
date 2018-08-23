/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class GetVertex : GraphTest
    {
        [Test]
        public void Directed()
        {
            var graph = GetTestDirectedGraph();

            for (var i = 0; i < 20; i++)
            {
                var vertex = graph.GetVertex(i);

                Assert.IsNotNull(vertex);
                Assert.AreEqual(vertex.Data, i);
            }

            Assert.IsNull(graph.GetVertex(21));
        }

        [Test]
        public void Undirected()
        {
            var graph = GetTestUndirectedGraph();

            for (var i = 0; i < 20; i++)
            {
                var vertex = graph.GetVertex(i);

                Assert.IsNotNull(vertex);
                Assert.AreEqual(vertex.Data, i);
            }

            Assert.IsNull(graph.GetVertex(21));
        }
    }
}