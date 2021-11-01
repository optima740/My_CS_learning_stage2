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
    public class PlanetAttributePrinterTest
    {        
        protected Mock<IOutput> _printInConsoleMock; 
        protected Planet _planet;
        protected IPrinter _printer; 

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            _planet = fixture.Create<Planet>();
            _printInConsoleMock = new Mock<IOutput>();
            _printer = new PlanetAttributePrinter(_printInConsoleMock.Object);
        }

        [Test]
        public void PlanetAttributePrinter_ShouldPrintPlanetAttributes()
        {
            //Act
            _printer.Print(_planet);

            //Assert
            _printInConsoleMock.Verify(output => output.WriteLine(It.IsAny<string>()), Times.Exactly(6));
        }
    }
}