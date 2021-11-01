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
    public class BlackHoleAttributePrinterTest
    {        
        protected Mock<IOutput> _printInConsoleMock; 
        protected BlackHole _blackHole;
        protected IPrinter _printer; 

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            _blackHole = fixture.Create<BlackHole>();
            _printInConsoleMock = new Mock<IOutput>();
            _printer = new BlackHoleAttributePrinter(_printInConsoleMock.Object);
        }

        [Test]
        public void BlackHoleAttributePrinter_ShouldPrintBlackHoleAttributes()
        {
            //Act
            _printer.Print(_blackHole);

            //Assert
            _printInConsoleMock.Verify(output => output.WriteLine(It.IsAny<string>()), Times.Exactly(6));
        }
    }
}