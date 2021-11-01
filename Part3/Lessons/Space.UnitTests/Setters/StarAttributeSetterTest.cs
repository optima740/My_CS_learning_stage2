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
    public class StarAttributeSetterTest
    {
        protected Mock<IInput> _readFromConsoleMock;
        protected Mock<IOutput> _printInConsoleMock;  
        protected Star _star;
        protected ISetter _setter;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            _star = fixture.Create<Star>();
            _printInConsoleMock = new Mock<IOutput>();
            _readFromConsoleMock = new Mock<IInput>();
            _setter = new StarAttributeSetter(_printInConsoleMock.Object, _readFromConsoleMock.Object);
        }

        [Test]
        public void StarAttributeSetter_ShouldSetStarAttributes()
        {
            //Act
            _setter.SetAttributs(_star);

            //Assert          
            _readFromConsoleMock.Verify(input => input.ReadLine(), Times.Exactly(5));         
        }

        [Test]
        public void IncorrectInput_ShouldThrowExeption()
        {
            //Arrange
          
            _readFromConsoleMock.Setup(input => input.ReadLine()).Returns(String.Empty);

            //Act
            var exception = NUnit.Framework.Assert.Throws<Exception>(() => _setter.SetAttributs(_star));

            //Assert
            NUnit.Framework.Assert.IsNotNull(exception);
            _readFromConsoleMock.Verify(input => input.ReadLine(), Times.Exactly(2));
        }
    }
}