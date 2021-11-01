using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Space.AttributePrinters;
using Space.InputOutput;
using Space.Models;

namespace Space.UnitTests.Printers
{
    [TestClass]
    public class AsteroidAttributePrinterTest
    {        
        protected Mock<IOutput> _printInConsoleMock; 
        protected Asteroid _asteroid;
        protected IPrinter _printer; 

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            _asteroid = fixture.Create<Asteroid>();
            _printInConsoleMock = new Mock<IOutput>();
            _printer = new AsteroidAttributePrinter(_printInConsoleMock.Object);
        }

        [Test]
        public void AsteroidAttributePrinter_ShouldPrintAsteroidAttributes()
        {
            //Act
            _printer.Print(_asteroid);

            //Assert
            _printInConsoleMock.Verify(output => output.WriteLine(It.IsAny<string>()), Times.Exactly(6));
        }
    }
}