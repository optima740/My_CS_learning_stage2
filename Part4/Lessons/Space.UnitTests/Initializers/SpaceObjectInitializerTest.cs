using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Space.Initializers;
using Space.Models;

namespace Space.UnitTests.Initializers
{
    [TestClass]
    class SpaceObjectInitializerTest
    {
        protected Asteroid _asteroid;
        protected BlackHole _blackHole;
        protected Planet _planet;
        protected Star _star;       

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            _star = fixture.Create<Star>();
            _asteroid = fixture.Create<Asteroid>();
            _blackHole = fixture.Create<BlackHole>();
            _planet = fixture.Create<Planet>();
        }

        [Test]
        public void InitializeStar_ShouldInitializeStar()
        {
            //Act
            var starInit = SpaceObjectInitializer.Initialize(_star);

            //Assert
            NUnit.Framework.Assert.AreEqual(starInit.TypeObj, "Star");
            NUnit.Framework.Assert.AreEqual(starInit.Name, "NewStar");
            NUnit.Framework.Assert.AreEqual(starInit.DegOfIllumination, 4.0f);
        }

        [Test]
        public void InitializeAsteroid_ShouldInitializeAsteroid()
        {
            //Act
            var asteroidInit = SpaceObjectInitializer.Initialize(_asteroid);

            //Assert
            NUnit.Framework.Assert.AreEqual(asteroidInit.TypeObj, "Asteroid");
            NUnit.Framework.Assert.AreEqual(asteroidInit.Name, "NewAsteroid");
            NUnit.Framework.Assert.AreEqual(asteroidInit.Speed, 50.0f);
        }

        [Test]
        public void InitializeBlackHole_ShouldInitializeBlackHole()
        {
            //Act
            var blackHoleInit = SpaceObjectInitializer.Initialize(_blackHole);

            //Assert
            NUnit.Framework.Assert.AreEqual(blackHoleInit.TypeObj, "BlackHole");
            NUnit.Framework.Assert.AreEqual(blackHoleInit.Name, "NewBlackHole");
            NUnit.Framework.Assert.AreEqual(blackHoleInit.Density, 8.0f);
        }

        [Test]
        public void InitializePlanet_ShouldInitializePlanet()
        {
            //Act
            var planetInit = SpaceObjectInitializer.Initialize(_planet);

            //Assert
            NUnit.Framework.Assert.AreEqual(planetInit.TypeObj, "Planet");
            NUnit.Framework.Assert.AreEqual(planetInit.Name, "NewPlanet");
            NUnit.Framework.Assert.AreEqual(planetInit.TiltAngle, 1.4f);
        }
    }
}
