/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using NGenerics.Algorithms;
using NUnit.Framework;

namespace NGenerics.Tests.Algorithms.Math.HypotenuseTests
{
    [TestFixture]
    public class Hypotenuse
    {
        [Test]
        public void Simple()
        {
            var a = 4;
            var b = 8;

            var hyp = MathAlgorithms.Hypotenuse(a, b);

            Assert.AreEqual(hyp, System.Math.Sqrt(80));

            a = 8;
            b = 4;
            hyp = MathAlgorithms.Hypotenuse(a, b);

            Assert.AreEqual(hyp, System.Math.Sqrt(80));

            a = 0;
            b = 0;
            hyp = MathAlgorithms.Hypotenuse(a, b);
            Assert.AreEqual(hyp, 0);
        }
    }

}