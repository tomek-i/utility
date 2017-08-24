using System;
using NUnit.Framework;
using TIUtilities.Logic;

namespace TIUtilities.UnitTests
{
    [TestFixture]
    public class TypeMappingUnitTests
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
            Assert.IsNotNull(TypeMapping.Get<object>());
        }

        [Test]
        public void RegisterType_OfANewType_CanRegister()
        {
            //ARRANGE
            string theInstanceToReturn = "test";
            Type theTypeToRegister = typeof(object);

            //ACT
            TypeMapping.Map(theTypeToRegister, theInstanceToReturn);

            //ASSERT
            Assert.IsNotNull(TypeMapping.Get(theTypeToRegister));
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
            TypeMapping.Map(theTypeToRegister, theInstanceToRegister);

            //ASSERT
            Assert.Throws<ArgumentException>(() => TypeMapping.Map(theTypeToRegister, theInstanceToReturn));
        }
        [Test]
        public void GetInstance_OfAlreadyRegisteredType_ReturnsTheRegisteredInstance()
        {
            //ARRANGE
            string theInstanceToReturn = "test";
            Type theTypeToRegister = typeof (object);

            TypeMapping.Map(theTypeToRegister, theInstanceToReturn);
            //ACT
            var result = TypeMapping.Get(typeof (object));
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
            var result = TypeMapping.Get<object>();
            //ASSERT
            Assert.AreSame(theInstanceToReturn, result);
        }
        [Test]
        public void GetInstance_OfNotARegisteredType_ReturnsNull()
        {
            //ARRANGE
            string theInstanceToReturn = "test";
            Type theTypeToRegister = typeof(object);

            TypeMapping.Map(theTypeToRegister, theInstanceToReturn);
            //ACT
            var result = TypeMapping.Get(typeof(int));
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
            var result = TypeMapping.Get<string>();
            //ASSERT
            Assert.IsNull(result);
        }
    }
}