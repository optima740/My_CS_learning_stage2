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
    public class AddAsteroidOperationTest
    {
        protected Mock<ISpaceObjectRepository> _repositoryMock;
        protected Mock<IOutput> _printInConsoleMock;
        protected Mock<IInput> _readFromConsoleMock;
        protected Mock<ISetter> _setter;
        protected AddAsteroidOperation _addAsteroidOperation;
        

        [SetUp]
        public void Setup()
        {
            _printInConsoleMock = new Mock<IOutput>();
            _readFromConsoleMock = new Mock<IInput>();
            _setter = new Mock<ISetter>();
            _repositoryMock = new Mock<ISpaceObjectRepository>();
            _addAsteroidOperation = new AddAsteroidOperation(_repositoryMock.Object, _setter.Object, _printInConsoleMock.Object, _readFromConsoleMock.Object);
        }

        [Test]
        public void AddAsteroidOperation_ShouldAddAsteroid()
        {
            //Act
            _addAsteroidOperation.DoOperation();

            //Assert
            _setter.Verify(s => s.SetAttributs(It.IsAny<Asteroid>()));
            _repositoryMock.Verify(repo => repo.Insert(It.IsAny<Asteroid>()));
            _repositoryMock.Verify(repo => repo.Save());
        }

        [Test]
        
        public void IncorrectAddAsteroidOperation_ShouldntAddAsteroid()
        {
            //Arrange           
            var asteroidSetter = new AsteroidAttributeSetter(_printInConsoleMock.Object, _readFromConsoleMock.Object);
            _addAsteroidOperation = new AddAsteroidOperation(_repositoryMock.Object, asteroidSetter, _printInConsoleMock.Object, _readFromConsoleMock.Object);
            _readFromConsoleMock.Setup(input => input.ReadLine()).Returns(String.Empty);

            //Act
            _addAsteroidOperation.DoOperation();

            //Assert
            _repositoryMock.Verify(repo => repo.Insert(It.IsAny<Asteroid>()), Times.Never);
            _repositoryMock.Verify(repo => repo.Save(), Times.Never);
            _printInConsoleMock.Verify(output => output.WriteLine(It.IsAny<string>()));
        }
    }
}