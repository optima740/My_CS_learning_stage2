using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Space.AttributeSetters;
using Space.DataAccessLayer;
using Space.InputOutput;
using Space.Models;
using Space.Operations;
using System;

namespace Space.UnitTests.Operations
{
    [TestClass]
    public class AddPlanetOperationTest
    {
        protected Mock<ISpaceObjectRepository> _repositoryMock;
        protected Mock<IOutput> _printInConsoleMock;
        protected Mock<IInput> _readFromConsoleMock;
        protected Mock<ISetter> _setter;
        protected AddPlanetOperation _addPlanetOperation;     

        [SetUp]
        public void Setup()
        {
            _printInConsoleMock = new Mock<IOutput>();
            _readFromConsoleMock = new Mock<IInput>();
            _setter = new Mock<ISetter>();
            _repositoryMock = new Mock<ISpaceObjectRepository>();
            _addPlanetOperation = new AddPlanetOperation(_repositoryMock.Object, _setter.Object, _printInConsoleMock.Object, _readFromConsoleMock.Object);
        }

        [Test]
        public void AddPlanetOperation_ShouldAddPlanet()
        {   
            //Act
            _addPlanetOperation.DoOperation();

            //Assert
            _setter.Verify(s => s.SetAttributs(It.IsAny<Planet>()));
            _repositoryMock.Verify(repo => repo.Insert(It.IsAny<Planet>()));
            _repositoryMock.Verify(repo => repo.Save());
        }

        [Test]
        public void IncorrectAddPlanetOperation_ShouldntAddPlanet()
        {
            //Arrange           
            var planetSetter = new AsteroidAttributeSetter(_printInConsoleMock.Object, _readFromConsoleMock.Object);
            _addPlanetOperation = new AddPlanetOperation(_repositoryMock.Object, planetSetter, _printInConsoleMock.Object, _readFromConsoleMock.Object);
            _readFromConsoleMock.Setup(input => input.ReadLine()).Returns(String.Empty);

            //Act
            _addPlanetOperation.DoOperation();

            //Assert
            _repositoryMock.Verify(repo => repo.Insert(It.IsAny<Planet>()), Times.Never);
            _repositoryMock.Verify(repo => repo.Save(), Times.Never);
            _printInConsoleMock.Verify(output => output.WriteLine(It.IsAny<string>()));
        }
    }
}