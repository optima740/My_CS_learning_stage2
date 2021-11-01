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
    public class StarAttributePrinterTest
    {        
        protected Mock<IOutput> _printInConsoleMock; 
        protected Star _star;
        protected IPrinter _printer; 

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            _star = fixture.Create<Star>();
            _printInConsoleMock = new Mock<IOutput>();
            _printer = new StarAttributePrinter(_printInConsoleMock.Object);
        }

        [Test]
        public void AsteroidAttributePrinter_ShouldPrintAsteroidAttributes()
        {
            //Act
            _printer.Print(_star);

            //Assert
            _printInConsoleMock.Verify(output => output.WriteLine(It.IsAny<string>()), Times.Exactly(6));
        }
    }
}