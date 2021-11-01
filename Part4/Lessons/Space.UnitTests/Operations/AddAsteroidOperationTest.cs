using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Space.AttributeSetters;
using Space.DataAccessLayer;
using Space.InputOutput;
using Space.Models;
using Space.Operations;
using System;
using System.Threading.Tasks;

namespace Space.UnitTests.Operations
{
    [TestClass]
    public class AddAsteroidOperationTest
    {
        protected Mock<ISpaceObjectRepository> _repositoryMock;
        protected Mock<IOutput> _printInConsoleMock;
        protected Mock<IInput> _readFromConsoleMock;
        protected Mock<ISetter> _setterMock;
        protected AddAsteroidOperation _addAsteroidOperation;       

        [SetUp]
        public void Setup()
        {
            _printInConsoleMock = new Mock<IOutput>();
            _readFromConsoleMock = new Mock<IInput>();
            _setterMock = new Mock<ISetter>();
            _repositoryMock = new Mock<ISpaceObjectRepository>();
            _addAsteroidOperation = new AddAsteroidOperation(_repositoryMock.Object, _setterMock.Object, _printInConsoleMock.Object, _readFromConsoleMock.Object);
        }

        [Test]
        public async Task AddAsteroidOperation_ShouldAddAsteroid()
        {
            //Act
            await _addAsteroidOperation.DoOperationAsync();

            //Assert
            _setterMock.Verify(s => s.SetAttributs(It.IsAny<Asteroid>()));
            _repositoryMock.Verify(repo => repo.InsertAsync(It.IsAny<Asteroid>()));
            _repositoryMock.Verify(repo => repo.SaveAsync());
        }

        [Test]
        
        public async Task IncorrectAddAsteroidOperation_ShouldntAddAsteroid()
        {
            //Arrange                              
            _setterMock.Setup(set => set.SetAttributs(It.IsAny<Asteroid>())).Throws(new FormatException());

            //Act
            await _addAsteroidOperation.DoOperationAsync();            

            //Assert
            _repositoryMock.Verify(repo => repo.InsertAsync(It.IsAny<Asteroid>()), Times.Never);
            _repositoryMock.Verify(repo => repo.SaveAsync(), Times.Never);
            _printInConsoleMock.Verify(output => output.WriteLine(It.IsAny<string>()));
        }
    }
}