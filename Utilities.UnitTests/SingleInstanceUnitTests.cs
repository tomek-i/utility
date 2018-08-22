using System;
using System.Security.Principal;
using System.Threading;
using NUnit.Framework;
using TI.Utilities;

namespace TI.Utilities.UnitTests
{
    [TestFixture]
    public class SingleInstanceUnitTests
    {
        [Test]
        public void SingleInstance_WhenCreatedHandle_IsTrue()
        {
            //ARRANGE
            var instance = new SingleInstance(100);

            //ACT
            var result = instance.HasHandle;

            //ASSERT
            Assert.That(result, Is.True);
        }
        [Test]
        public void SingleInstance_SecondInstance_Throws()
        {
            //ARRANGE
            SingleInstance instance = new SingleInstance(3000);
                       
            //ACT
            var result = new ThreadStart(() => {
                new SingleInstance(300);
            });

            //ASSERT

            Assert.That(() =>
            {
                result.Invoke();
            }, Throws.InstanceOf<TimeoutException>());


        }

    }
}
