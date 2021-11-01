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
using System.Linq;
using System.Threading.Tasks;

namespace Space.UnitTests.Operations
{
    [TestClass]
    public class PrintAllAsteroidsOperationTest
    {
        protected Mock<IPrinter> _asteroidPrinterMock;
        protected Mock<ISpaceObjectRepository> _repositoryMock;
        protected Mock<IOutput> _printInConsoleMock;     
        protected Asteroid _asteroid;     

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            _asteroid = fixture.Create<Asteroid>();
            _printInConsoleMock = new Mock<IOutput>();
            _repositoryMock = new Mock<ISpaceObjectRepository>();
            _asteroidPrinterMock = new Mock<IPrinter>();
        }

        [Test]
        public async Task PrintAllAsteroidsOperation_ShouldPrintAsteroidAttributes()
        {
            //Arrange            
            var printAllBlackHolesOperation = new PrintAllAsteroidsOperation(_repositoryMock.Object, _asteroidPrinterMock.Object, _printInConsoleMock.Object);
            var asteroidsCollection = new List<Asteroid> { _asteroid };           
            _repositoryMock.Setup(repo => repo.GetAllByTypeAsync<Asteroid>()).Returns(asteroidsCollection.ToAsyncEnumerable());

            //Act
            await printAllBlackHolesOperation.DoOperationAsync();

            //Assert          
            _asteroidPrinterMock.Verify(p => p.Print(_asteroid));
        }
    }
}