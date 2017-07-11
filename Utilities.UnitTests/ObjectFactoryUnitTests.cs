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
            TypeMapping.Clear();
        }

        [Test]
        public void RegisterTypeT_OfANewType_CanRegister()
        {
            //ARRANGE
            string theInstanceToReturn = "test";
          

            //ACT
            TypeMapping.Map<object>(theInstanceToReturn);

            //ASSERT
            Assert.IsNotNull(TypeMapping.GetInstance<object>());
        }

        [Test]
        public void RegisterType_OfANewType_CanRegister()
        {
            //ARRANGE
            string theInstanceToReturn = "test";
            Type theTypeToRegister = typeof(object);

            //ACT
            TypeMapping.RegisterType(theTypeToRegister, theInstanceToReturn);

            //ASSERT
            Assert.IsNotNull(TypeMapping.GetInstance(theTypeToRegister));
        }
        [Test]
        public void RegisterTypeT_OfAlreadyRegistered_Throws()
        {
            //ARRANGE
            string theInstanceToRegister = "test";
            string theInstanceToReturn = "new";
           

            //ACT
            TypeMapping.Map<object>(theInstanceToRegister);

            //ASSERT
            Assert.Throws<ArgumentException>(() => TypeMapping.Map<object>(theInstanceToReturn));
        }
        [Test]
        public void RegisterType_OfAlreadyRegistered_Throws()
        {
            //ARRANGE
            string theInstanceToRegister = "test";
            string theInstanceToReturn = "new";
            Type theTypeToRegister = typeof(object);

            //ACT
            TypeMapping.RegisterType(theTypeToRegister, theInstanceToRegister);

            //ASSERT
            Assert.Throws<ArgumentException>(() => TypeMapping.RegisterType(theTypeToRegister, theInstanceToReturn));
        }
        [Test]
        public void GetInstance_OfAlreadyRegisteredType_ReturnsTheRegisteredInstance()
        {
            //ARRANGE
            string theInstanceToReturn = "test";
            Type theTypeToRegister = typeof (object);

            TypeMapping.RegisterType(theTypeToRegister, theInstanceToReturn);
            //ACT
            var result = TypeMapping.GetInstance(typeof (object));
            //ASSERT
            Assert.AreSame(theInstanceToReturn, result);
        }
        [Test]
        public void GetInstanceT_OfAlreadyRegisteredType_ReturnsTheRegisteredInstance()
        {
            //ARRANGE
            string theInstanceToReturn = "test";
          

            TypeMapping.Map<object>(theInstanceToReturn);
            //ACT
            var result = TypeMapping.GetInstance<object>();
            //ASSERT
            Assert.AreSame(theInstanceToReturn, result);
        }
        [Test]
        public void GetInstance_OfNotARegisteredType_ReturnsNull()
        {
            //ARRANGE
            string theInstanceToReturn = "test";
            Type theTypeToRegister = typeof(object);

            TypeMapping.RegisterType(theTypeToRegister, theInstanceToReturn);
            //ACT
            var result = TypeMapping.GetInstance(typeof(int));
            //ASSERT
            Assert.IsNull(result);
        }
        [Test]
        public void GetInstanceT_OfNotARegisteredType_ReturnsNull()
        {
            //ARRANGE
            string theInstanceToReturn = "test";
           

            TypeMapping.Map<object>(theInstanceToReturn);
            //ACT
            var result = TypeMapping.GetInstance<string>();
            //ASSERT
            Assert.IsNull(result);
        }
    }
}