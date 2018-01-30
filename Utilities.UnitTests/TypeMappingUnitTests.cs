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
            TypeMapping.Map<object>(theInstanceToReturn);

            //ACT
            var result = TypeMapping.Get<object, object>();
            //ASSERT

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void RegisterType_OfANewType_CanRegister()
        {
            //ARRANGE
            string theInstanceToReturn = "test";
            Type theTypeToRegister = typeof(object);
            TypeMapping.Map(theTypeToRegister, theInstanceToReturn);

            //ACT
            var result = TypeMapping.Get(theTypeToRegister);

            //ASSERT
            Assert.That(result, Is.Not.Null);

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
            Assert.That(() =>
            {
                TypeMapping.Map<object>(theInstanceToReturn);
            }, Throws.ArgumentException);
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
            Assert.That(() =>
            {
                TypeMapping.Map(theTypeToRegister, theInstanceToReturn);
            }, Throws.ArgumentException);


        }
        [Test]
        public void GetInstance_OfAlreadyRegisteredType_ReturnsTheRegisteredInstance()
        {
            //ARRANGE
            string theInstanceToReturn = "test";
            Type theTypeToRegister = typeof(object);

            TypeMapping.Map(theTypeToRegister, theInstanceToReturn);
            //ACT
            var result = TypeMapping.Get(typeof(object));
            //ASSERT
            Assert.That(result, Is.SameAs(theInstanceToReturn));
        }
        [Test]
        public void GetInstanceT_OfAlreadyRegisteredType_ReturnsTheRegisteredInstance()
        {
            //ARRANGE
            string theInstanceToReturn = "test";


            TypeMapping.Map<object>(theInstanceToReturn);
            //ACT
            var result = TypeMapping.Get<object, object>();
            //ASSERT


            Assert.That(result, Is.SameAs(theInstanceToReturn));
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
            Assert.That(result, Is.Null);
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
            Assert.That(result, Is.Null);
        }


        [Test]
        public void GetInstanceT_OfRegisteredType_ReturnsValue()
        {
            //ARRANGE
            string theInstanceToReturn = "test";

            TypeMapping.Map<string>(theInstanceToReturn);

            //ACT
            var result = TypeMapping.Get<string>();

            //ASSERT
            Assert.That(result, Is.Not.Null);



            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo("test"));
                Assert.That(result, Is.SameAs(theInstanceToReturn), "Not same instance");
            });



        }
    }
}