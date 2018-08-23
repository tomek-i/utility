/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SetTests
{
    [TestFixture]
    public class IsProperSubsetOf
    {

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidProperSubsetOf()
        {
            var s1 = new PascalSet(0, 50, new[] { 15, 20, 30 });
            var s2 = new PascalSet(10, 60, new[] { 15, 20, 60 });

            s1.IsProperSubsetOf(s2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExcetpionNullS1()
        {
            var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });
            var b = null < pascalSet;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullS2()
        {
            var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });
            var b = pascalSet < null;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullSet()
        {
            var pascalSet = new PascalSet(500);
            pascalSet.IsProperSubsetOf(null);
        }

        [Test]
        public void Simple()
        {
            var s1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
            var s2 = new PascalSet(0, 50, new[] { 15, 20, 30 });
            var s3 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

            Assert.IsFalse(s1.IsProperSubsetOf(s2));
            Assert.IsTrue(s2.IsProperSubsetOf(s1));
            Assert.IsFalse(s3.IsProperSubsetOf(s1));
            Assert.IsFalse(s1.IsProperSubsetOf(s3));

            Assert.IsFalse(s1 < s2);
            Assert.IsTrue(s2 < s1);
            Assert.IsFalse(s3 < s1);
            Assert.IsFalse(s1 < s3);
        }

        [Test]
        public void Interface()
        {
            var s1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
            var s2 = new PascalSet(0, 50, new[] { 15, 20, 30 });
            var s3 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

            Assert.IsFalse(((ISet)s1).IsProperSubsetOf(s2));
            Assert.IsTrue(((ISet)s2).IsProperSubsetOf(s1));
            Assert.IsFalse(((ISet)s3).IsProperSubsetOf(s1));
            Assert.IsFalse(((ISet)s1).IsProperSubsetOf(s3));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullS1()
        {
            var pascalSet = new PascalSet(500);
            var p = null < pascalSet;
        }

    }
}