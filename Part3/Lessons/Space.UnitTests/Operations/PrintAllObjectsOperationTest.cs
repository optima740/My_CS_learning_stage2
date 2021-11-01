using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Space.AttributePrinters;
using Space.DataAccessLayer;
using Space.InputOutput;
using Space.Models;
using Space.Operations;
using System.Collections.Generic;

namespace Space.UnitTests.Operations
{
    [TestClass]
    public class PrintAllObjectsOperationTest
    {
        protected Mock<ISpaceObjectRepository> _repositoryMock;
        protected Mock<IOutput> _printInConsoleMock;
        protected Mock<IPrinter> _allPrinterMock;
        protected Star _star;
        protected Asteroid _asteroid;
        protected BlackHole _blackHole;
        protected Planet _planet;        
        protected IOperation _printAllOperation;
        protected List<SpaceObject> _objectsCollection;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            _star = fixture.Create<Star>();
            _asteroid = fixture.Create<Asteroid>();
            _blackHole = fixture.Create<BlackHole>();
            _planet = fixture.Create<Planet>();
            _printInConsoleMock = new Mock<IOutput>();          
            _repositoryMock = new Mock<ISpaceObjectRepository>();
            _allPrinterMock = new Mock<IPrinter>();
            _printAllOperation = new PrintAllObjectsOperation(_repositoryMock.Object, _allPrinterMock.Object, _printInConsoleMock.Object);
            _objectsCollection = new List<SpaceObject> { _star, _asteroid, _planet, _blackHole };
        }

        [Test]
        public void AllPrintOperation_ShouldPrintAllObjects()
        {
            //Arrange                          
            _repositoryMock.Setup(repo => repo.GetAllByType<SpaceObject>()).Returns(_objectsCollection);

            //Act
            _printAllOperation.DoOperation();

            //Assert          
            _allPrinterMock.Verify(p => p.Print(_planet));
            _allPrinterMock.Verify(p => p.Print(_star));
            _allPrinterMock.Verify(p => p.Print(_asteroid));
            _allPrinterMock.Verify(p => p.Print(_blackHole));
        }

        [Test]
        public void PrintModelNotContains_ShouldntPrintModelAttributes()
        {
            //Arrange            
            var spaceObjectsCollection = new List<SpaceObject> { };
            _repositoryMock.Setup(repo => repo.GetAllByType<SpaceObject>()).Returns(spaceObjectsCollection);

            //Act
            _printAllOperation.DoOperation();

            //Assert          
            _allPrinterMock.Verify(p => p.Print(It.IsAny<SpaceObject>()), Times.Never);
        }
    }
}