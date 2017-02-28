using System;
using NUnit.Framework;
using TIUtilities.Logic;

namespace TIUtilities.UnitTests
{
    [TestFixture]
    public class ObjectFactoryUnitTests
    {
        [TearDown]
        public void Clear()
        {
            ObjectFactory.Clear();
        }

        [Test]
        public void RegisterTypeT_OfANewType_CanRegister()
        {
            //ARRANGE
            string theInstanceToReturn = "test";
          

            //ACT
            ObjectFactory.RegisterType<object>(theInstanceToReturn);

            //ASSERT
            Assert.IsNotNull(ObjectFactory.GetInstance<object>());
        }

        [Test]
        public void RegisterType_OfANewType_CanRegister()
        {
            //ARRANGE
            string theInstanceToReturn = "test";
            Type theTypeToRegister = typeof(object);

            //ACT
            ObjectFactory.RegisterType(theTypeToRegister, theInstanceToReturn);

            //ASSERT
            Assert.IsNotNull(ObjectFactory.GetInstance(theTypeToRegister));
        }
        [Test]
        public void RegisterTypeT_OfAlreadyRegistered_Throws()
        {
            //ARRANGE
            string theInstanceToRegister = "test";
            string theInstanceToReturn = "new";
           

            //ACT
            ObjectFactory.RegisterType<object>(theInstanceToRegister);

            //ASSERT
            Assert.Throws<ArgumentException>(() => ObjectFactory.RegisterType<object>(theInstanceToReturn));
        }
        [Test]
        public void RegisterType_OfAlreadyRegistered_Throws()
        {
            //ARRANGE
            string theInstanceToRegister = "test";
            string theInstanceToReturn = "new";
            Type theTypeToRegister = typeof(object);

            //ACT
            ObjectFactory.RegisterType(theTypeToRegister, theInstanceToRegister);

            //ASSERT
            Assert.Throws<ArgumentException>(() => ObjectFactory.RegisterType(theTypeToRegister, theInstanceToReturn));
        }
        [Test]
        public void GetInstance_OfAlreadyRegisteredType_ReturnsTheRegisteredInstance()
        {
            //ARRANGE
            string theInstanceToReturn = "test";
            Type theTypeToRegister = typeof (object);

            ObjectFactory.RegisterType(theTypeToRegister, theInstanceToReturn);
            //ACT
            var result = ObjectFactory.GetInstance(typeof (object));
            //ASSERT
            Assert.AreSame(theInstanceToReturn, result);
        }
        [Test]
        public void GetInstanceT_OfAlreadyRegisteredType_ReturnsTheRegisteredInstance()
        {
            //ARRANGE
            string theInstanceToReturn = "test";
          

            ObjectFactory.RegisterType<object>(theInstanceToReturn);
            //ACT
            var result = ObjectFactory.GetInstance<object>();
            //ASSERT
            Assert.AreSame(theInstanceToReturn, result);
        }
        [Test]
        public void GetInstance_OfNotARegisteredType_ReturnsNull()
        {
            //ARRANGE
            string theInstanceToReturn = "test";
            Type theTypeToRegister = typeof(object);

            ObjectFactory.RegisterType(theTypeToRegister, theInstanceToReturn);
            //ACT
            var result = ObjectFactory.GetInstance(typeof(int));
            //ASSERT
            Assert.IsNull(result);
        }
        [Test]
        public void GetInstanceT_OfNotARegisteredType_ReturnsNull()
        {
            //ARRANGE
            string theInstanceToReturn = "test";
           

            ObjectFactory.RegisterType<object>(theInstanceToReturn);
            //ACT
            var result = ObjectFactory.GetInstance<string>();
            //ASSERT
            Assert.IsNull(result);
        }
    }
}