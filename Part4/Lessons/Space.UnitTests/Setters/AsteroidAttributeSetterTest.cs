using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Space.AttributeSetters;
using Space.InputOutput;
using Space.Models;
using System;

namespace Space.UnitTests.Stetters
{
    [TestClass]
    public class AsteroidAttributeSetterTest
    {
        protected Mock<IInput> _readFromConsoleMock;
        protected Mock<IOutput> _printInConsoleMock; 
        protected Asteroid _asteroid;
        protected ISetter _setter;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            _asteroid = fixture.Create<Asteroid>();
            _printInConsoleMock = new Mock<IOutput>();
            _readFromConsoleMock = new Mock<IInput>();
            _setter = new AsteroidAttributeSetter(_printInConsoleMock.Object, _readFromConsoleMock.Object);
        }

        [Test]
        public void AsteroidAttributeSetter_ShouldSetAsteroidAttributes()
        {
            //Act
            _setter.SetAttributs(_asteroid);

            //Assert          
            _readFromConsoleMock.Verify(input => input.ReadLine(), Times.Exactly(1));
            _readFromConsoleMock.Verify(input => input.ReadFloat(), Times.Exactly(4));
        }

        [Test]
        public void IncorrectInput_ShouldThrowExeption()
        {
            //Arrange          
            _readFromConsoleMock.Setup(input => input.ReadFloat()).Throws(new FormatException());

            //Act
            var exception = NUnit.Framework.Assert.Throws<Exception>(() => _setter.SetAttributs(_asteroid));

            //Assert
            NUnit.Framework.Assert.IsNotNull(exception);
            NUnit.Framework.Assert.AreEqual("Вы ввели недопустимое значение, объект не создан!", exception.Message);
            _readFromConsoleMock.Verify(input => input.ReadLine(), Times.Once);
            _readFromConsoleMock.Verify(input => input.ReadFloat(), Times.Once);
        }
    }
}