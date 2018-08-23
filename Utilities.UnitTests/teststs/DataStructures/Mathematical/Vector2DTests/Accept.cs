/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class Accept
    {

        [Test]
        public void Simple()
        {
            var visitor = new CountingVisitor<double>();
            var vector2D = new Vector2D();
            vector2D.AcceptVisitor(visitor);
            Assert.AreEqual(2, visitor.Count);
        }

        [Test]
        public void HasCompletedPre()
        {
            var visitor = new ComparableFindingVisitor<double>(2);
            visitor.Visit(2);
            var vector2D = new Vector2D();
            vector2D.SetValues(2, 5);
            vector2D.AcceptVisitor(visitor);
            Assert.IsTrue(visitor.Found);
        }

        [Test]
        public void HasCompletedPost()
        {
            var visitor = new ComparableFindingVisitor<double>(2);
            var vector2D = new Vector2D();
            vector2D.SetValues(2, 5);
            vector2D.AcceptVisitor(visitor);
            Assert.IsTrue(visitor.Found);
        }

    }
}