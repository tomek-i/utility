using NUnit.Framework;
using TI.Utilities.Extensions;

namespace TI.Utilities.UnitTests
{

    [TestFixture]
    public class DoubleExtensionsExamples
    {
        #region IsSimilarTo

        [Test]
        public void IsSimilarToExample()
        {
            var d1 = 5.000000000009d;
            var d2 = 5d;

            // Since the difference between the two values are less / equal than the default precision,
            // the following statement returns true :
            Assert.IsTrue(d1.IsSimilarTo(d2));
        }

        #endregion

        #region IsSimilarWithPrecision

        [Test]
        public void IsSimilarWithPrecisionExample()
        {
            var d1 = 5.1d;
            var d2 = 5d;

            // Since the difference between the two values are less / equal than the supplied precision,
            // the following statement returns true :
            Assert.IsTrue(d1.IsSimilarTo(d2, 0.1));
        }

        #endregion
    }


    [TestFixture]
    public class StringCipherUnitTests
    {

        
    }
}