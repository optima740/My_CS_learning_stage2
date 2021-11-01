using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Space.DataAccessLayer;
using Space.InputOutput;
using Space.Models;
using Space.Operations;

namespace Space.UnitTests.Operations
{
    [TestClass]
    public class RemoveOperationTest
    {
        protected Mock<ISpaceObjectRepository> _repositoryMock;
        protected Mock<IOutput> _printInConsoleMock;
        protected Mock<IInput> _readFromConsoleMock;
        protected RemoveObjectOperation _removeOperation;        

        [SetUp]
        public void Setup()
        {
            _printInConsoleMock = new Mock<IOutput>();
            _readFromConsoleMock = new Mock<IInput>();
            _repositoryMock = new Mock<ISpaceObjectRepository>();
            _removeOperation = new RemoveObjectOperation(_repositoryMock.Object, _printInConsoleMock.Object, _readFromConsoleMock.Object);
        }

        [Test]
        public void RemoveModel_ShouldRemoveModel()
        {
            //Arrange           
            var planet = new Planet();
            var name = planet.Name;
            _readFromConsoleMock.Setup(input => input.ReadLine()).Returns(name);      
            _repositoryMock.Setup(repo => repo.IsContains(name)).Returns(true);
            _repositoryMock.Setup(repo => repo.Get(name)).Returns(planet);       

            //Act
            _removeOperation.DoOperation();

            //Assert
            _repositoryMock.Verify(repo => repo.Delete(planet.id));
            _repositoryMock.Verify(repo => repo.Save());
        }

        [Test]
        public void RemoveModelNotContainceName_ShouldntExecutedOperation()
        {
            //Arrange
            var star = new Star();
            var name = star.Name;
            _readFromConsoleMock.Setup(input => input.ReadLine()).Returns(name);
            _repositoryMock.Setup(repo => repo.IsContains(name)).Returns(false);
            _repositoryMock.Setup(repo => repo.Get(name)).Returns(star);

            //Act
            _removeOperation.DoOperation();

            //Assert
            _repositoryMock.Verify(repo => repo.Delete(star.id), Times.Never);
            _repositoryMock.Verify(repo => repo.Save(), Times.Never);
        }
    }
}
