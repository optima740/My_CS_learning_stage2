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
    public class PrintAllBlackHolesOperationTest
    {
        protected Mock<IPrinter> _blackHolePrinterMock;
        protected Mock<ISpaceObjectRepository> _repositoryMock;
        protected Mock<IOutput> _printInConsoleMock;     
        protected BlackHole _blackHole;     

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            _blackHole = fixture.Create<BlackHole>();  
            _printInConsoleMock = new Mock<IOutput>();          
            _repositoryMock = new Mock<ISpaceObjectRepository>();
            _blackHolePrinterMock = new Mock<IPrinter>();
        }

        [Test]
        public async Task PrintAllBlackHolesOperation_ShouldPrintBlackHoleAttributes()
        {
            //Arrange            
            var printAllBlackHolesOperation = new PrintAllBlackHolesOperation(_repositoryMock.Object, _blackHolePrinterMock.Object, _printInConsoleMock.Object);
            var blackHolesCollection = new List<BlackHole> { _blackHole };            
            _repositoryMock.Setup(repo => repo.GetAllByTypeAsync<BlackHole>()).Returns(blackHolesCollection.ToAsyncEnumerable());

            //Act
            await printAllBlackHolesOperation.DoOperationAsync();

            //Assert          
            _blackHolePrinterMock.Verify(p => p.Print(_blackHole));            
        }
    }
}