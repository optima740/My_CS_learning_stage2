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
    public class AllSpaceObjectsAttributePrinterTest
    {        
        protected Mock<IOutput> _printInConsoleMock;
        protected Star _star;
        protected Asteroid _asteroid;
        protected BlackHole _blackHole;
        protected Planet _planet;
        protected IPrinter _printer;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            _star = fixture.Create<Star>();
            _asteroid = fixture.Create<Asteroid>();
            _blackHole = fixture.Create<BlackHole>();
            _planet = fixture.Create<Planet>();
            _printInConsoleMock = new Mock<IOutput>();
            _printer = new AllSpaceObjectsPrinter(_printInConsoleMock.Object);            
        }

        [Test]
        public void AllSpaceObjectsAttributePrinter_ShouldPrintAllObjects()
        {
            //Act
            _printer.Print(_asteroid);
            _printer.Print(_star);
            _printer.Print(_blackHole);
            _printer.Print(_planet);

            //Assert
            _printInConsoleMock.Verify(output => output.WriteLine(It.IsAny<string>()), Times.Exactly(4));
        }
    }
}