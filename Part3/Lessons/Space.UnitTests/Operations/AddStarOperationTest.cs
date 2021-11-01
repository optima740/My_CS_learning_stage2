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
    public class AddStarOperationTest
    {
        protected Mock<ISpaceObjectRepository> _repositoryMock;
        protected Mock<IOutput> _printInConsoleMock;
        protected Mock<IInput> _readFromConsoleMock;
        protected Mock<ISetter> _setter;
        protected AddStarOperation _addStarOperation;     

        [SetUp]
        public void Setup()
        {
            _printInConsoleMock = new Mock<IOutput>();
            _readFromConsoleMock = new Mock<IInput>();
            _setter = new Mock<ISetter>();
            _repositoryMock = new Mock<ISpaceObjectRepository>();
            _addStarOperation = new AddStarOperation(_repositoryMock.Object, _setter.Object, _printInConsoleMock.Object, _readFromConsoleMock.Object);
        }

        [Test]
        public void AddStarOperation_ShouldAddStar()
        {   
            //Act
            _addStarOperation.DoOperation();

            //Assert
            _setter.Verify(s => s.SetAttributs(It.IsAny<Star>()));
            _repositoryMock.Verify(repo => repo.Insert(It.IsAny<Star>()));
            _repositoryMock.Verify(repo => repo.Save());
        }

        [Test]
        public void IncorrectAddStarOperation_ShouldntAddStar()
        {
            //Arrange           
            var starSetter = new AsteroidAttributeSetter(_printInConsoleMock.Object, _readFromConsoleMock.Object);
            _addStarOperation = new AddStarOperation(_repositoryMock.Object, starSetter, _printInConsoleMock.Object, _readFromConsoleMock.Object);
            _readFromConsoleMock.Setup(input => input.ReadLine()).Returns(String.Empty);

            //Act
            _addStarOperation.DoOperation();

            //Assert
            _repositoryMock.Verify(repo => repo.Insert(It.IsAny<Star>()), Times.Never);
            _repositoryMock.Verify(repo => repo.Save(), Times.Never);
            _printInConsoleMock.Verify(output => output.WriteLine(It.IsAny<string>()));
        }
    }
}