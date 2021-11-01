using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Space.DataAccessLayer;
using Space.InputOutput;
using Space.Models;
using Space.Operations;
using System.Threading.Tasks;

namespace Space.UnitTests.Operations
{
    [TestClass]
    public class RemoveOperationTest
    {
        protected Mock<ISpaceObjectRepository> _repositoryMock;
        protected Mock<IOutput> _printInConsoleMock;
        protected Mock<IInput> _readFromConsoleMock;
        protected RemoveObjectOperation _removeOperation;
        protected Planet _planet;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            _planet = fixture.Create<Planet>();
            _printInConsoleMock = new Mock<IOutput>();
            _readFromConsoleMock = new Mock<IInput>();
            _repositoryMock = new Mock<ISpaceObjectRepository>();
            _removeOperation = new RemoveObjectOperation(_repositoryMock.Object, _printInConsoleMock.Object, _readFromConsoleMock.Object);
        }

        [Test]
        public async Task RemoveModel_ShouldRemoveModel()
        {
            //Arrange                     
            var name = _planet.Name;
            _readFromConsoleMock.Setup(input => input.ReadLine()).Returns(name);      
            _repositoryMock.Setup(repo => repo.GetAsync(name)).ReturnsAsync(_planet);       

            //Act
            await _removeOperation.DoOperationAsync();

            //Assert
            _repositoryMock.Verify(repo => repo.DeleteAsync(_planet.id));
            _repositoryMock.Verify(repo => repo.SaveAsync());
        }

        [Test]
        public async Task RemoveModelNotContainceName_ShouldntExecutedOperation()
        {
            //Arrange
            SpaceObject spaceObj = null;           
            var name = "noname";
            _readFromConsoleMock.Setup(input => input.ReadLine()).Returns(name);
            _repositoryMock.Setup(repo => repo.GetAsync(name)).ReturnsAsync(spaceObj);

            //Act
            await _removeOperation.DoOperationAsync();

            //Assert
            _repositoryMock.Verify(repo => repo.DeleteAsync(_planet.id), Times.Never);
            _repositoryMock.Verify(repo => repo.SaveAsync(), Times.Never);            
        }
    }
}
