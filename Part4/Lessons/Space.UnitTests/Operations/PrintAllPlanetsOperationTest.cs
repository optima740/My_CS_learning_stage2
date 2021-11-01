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
    public class PrintAllPlanetsOperationTest
    {
        protected Mock<IPrinter> _planetPrinterMock;
        protected Mock<ISpaceObjectRepository> _repositoryMock;
        protected Mock<IOutput> _printInConsoleMock;     
        protected Planet _planet;      

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            _planet = fixture.Create<Planet>();  
            _printInConsoleMock = new Mock<IOutput>();          
            _repositoryMock = new Mock<ISpaceObjectRepository>();
            _planetPrinterMock = new Mock<IPrinter>();
        }

        [Test]
        public async Task PrintAllPlanetsOperation_ShouldPrintPlanetAttributes()
        {
            //Arrange            
            var printAllPlanetOperation = new PrintAllPlanetsOperation(_repositoryMock.Object, _planetPrinterMock.Object, _printInConsoleMock.Object);
            var planetsCollection = new List<Planet> { _planet };
            _repositoryMock.Setup(repo => repo.GetAllByTypeAsync<Planet>()).Returns(planetsCollection.ToAsyncEnumerable());

            //Act
            await printAllPlanetOperation.DoOperationAsync();

            //Assert          
            _planetPrinterMock.Verify(p => p.Print(_planet));
        }
    }
}