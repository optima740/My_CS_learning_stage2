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
    public class AddPlanetOperationTest
    {
        protected Mock<ISpaceObjectRepository> _repositoryMock;
        protected Mock<IOutput> _printInConsoleMock;
        protected Mock<IInput> _readFromConsoleMock;
        protected Mock<ISetter> _setterMock;
        protected AddPlanetOperation _addPlanetOperation;     

        [SetUp]
        public void Setup()
        {
            _printInConsoleMock = new Mock<IOutput>();
            _readFromConsoleMock = new Mock<IInput>();
            _setterMock = new Mock<ISetter>();
            _repositoryMock = new Mock<ISpaceObjectRepository>();
            _addPlanetOperation = new AddPlanetOperation(_repositoryMock.Object, _setterMock.Object, _printInConsoleMock.Object, _readFromConsoleMock.Object);
        }

        [Test]
        public async Task AddPlanetOperation_ShouldAddPlanet()
        {   
            //Act
            await _addPlanetOperation.DoOperationAsync();

            //Assert
            _setterMock.Verify(s => s.SetAttributs(It.IsAny<Planet>()));
            _repositoryMock.Verify(repo => repo.InsertAsync(It.IsAny<Planet>()));
            _repositoryMock.Verify(repo => repo.SaveAsync());
        }

        [Test]
        public async Task IncorrectAddPlanetOperation_ShouldntAddPlanet()
        {
            //Arrange                              
            _setterMock.Setup(set => set.SetAttributs(It.IsAny<Planet>())).Throws(new FormatException());

            //Act
            await _addPlanetOperation.DoOperationAsync();

            //Assert
            _repositoryMock.Verify(repo => repo.InsertAsync(It.IsAny<Planet>()), Times.Never);
            _repositoryMock.Verify(repo => repo.SaveAsync(), Times.Never);
            _printInConsoleMock.Verify(output => output.WriteLine(It.IsAny<string>()));
        }
    }
}