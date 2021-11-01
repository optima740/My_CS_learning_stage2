using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using SpaceObjects.Api.Controllers;
using SpaceObjects.Api.DataAccessLayer;
using SpaceObjects.Api.DTO;
using SpaceObjects.Api.Mapper;
using SpaceObjects.Api.Models;
using System.Threading.Tasks;

namespace SpaceObjects.Api.IntegrationTests.Controllers
{
    class AsteroidsControllerTests
    {
        [TestFixture]
        public class AsteroidsControllerTest
        {
            private AsteroidsController _controller;           
            private TestingDataBase _dataBase;
            private ApplicationSpaceObjectContext _context;
            private ISpaceObjectRepository _repository;
            private IMapper _mapper;

            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                _dataBase = new TestingDataBase();
                _context = _dataBase.Context;              
                _repository = new SpaceObjectRepository(_context);                           
                Utilities.InitializeDbTest(_context);
                
                var mapperConfig = new MapperConfiguration(cfg =>
                {                    
                    cfg.AddProfile<ProfileMapper>();
                });

                _mapper = mapperConfig.CreateMapper();
                _controller = new AsteroidsController(_repository, _mapper);
            }

            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                Utilities.ReinitializeDbTest(_context);
            }

            [Test]
            public async Task GetAll_ShouldReturnOKAndAsteroids()
            {
                var asteroid = new Asteroid()
                {
                    Id = 10,
                    Name = "NewAsteroid",
                    DistToSun = 1,
                    Weight = 2,
                    Diametr = 3,
                    Speed = 4
                };

                await _repository.InsertAsync(asteroid);
                await _repository.SaveAsync();

                var actualResponse = _controller.GetAll();
                var expectedAsteroids = _repository.GetAllByTypeAsync<Asteroid>();
                var objResponse = (OkObjectResult)actualResponse.Result;

                Assert.AreEqual(expectedAsteroids, objResponse.Value);
                Assert.AreEqual(200, objResponse.StatusCode);
            }

            [Test]
            public async Task GetAll_NotFound_ShouldReturnNotFound()
            {
                var asteroids = _repository.GetAllByTypeAsync<Asteroid>();
                
                await foreach(var asteroid in asteroids)
                {
                    await _repository.DeleteAsync(asteroid.Id);
                }
                
                await _repository.SaveAsync();

                asteroids = _repository.GetAllByTypeAsync<Asteroid>();
                var actualResponse = _controller.GetAll();                
                var objResponse = (ObjectResult)actualResponse.Result;
               
                Assert.AreEqual(200, objResponse.StatusCode);
                Assert.AreEqual(asteroids, objResponse.Value);
            }

            [Test]
            public async Task Get_SendRequestWithName_ShouldReturnOkAndAsteroid()
            {
                var asteroid = new Asteroid()
                {
                    Id = 20,
                    Name = "NewAsteroid",
                    DistToSun = 1,
                    Weight = 2,
                    Diametr = 3,
                    Speed = 4
                };

                await _repository.InsertAsync(asteroid);
                await _repository.SaveAsync();

                var actualResponse = await _controller.Get(20);
                var expectedAsteroid = await _repository.GetAsync(20);
                var objResponse = (ObjectResult)actualResponse.Result;

                Assert.AreEqual(expectedAsteroid, objResponse.Value);
                Assert.AreEqual(200, objResponse.StatusCode);
            }

            [Test]
            public async Task Get_SendRequestWithFakeName_ShouldReturnNotFound()
            {
                var actualResponse = await _controller.Get(100);
                var codeResponse = (StatusCodeResult)actualResponse.Result;

                Assert.AreEqual(404, codeResponse.StatusCode);
            }

            [Test]
            public async Task Create_ShouldCreatedAndInsertAsteroidAndReturnOK()
            {
                var asteroid = new AsteroidDto() 
                {                   
                    Name = "AsteroidCreateTest",
                    DistToSun = 1,
                    Weight = 2,
                    Diametr = 3,
                    Speed = 4
                };

                var actualResponse = await _controller.Create(asteroid);
                var codeResponse = (StatusCodeResult)actualResponse;

                Assert.AreEqual(201, codeResponse.StatusCode);
            }

            [Test]
            public async Task Update_ShouldUpdateAsteroidAndReturnOK()
            {
                var asteroid = new Asteroid()
                {
                    Id = 40,
                    Name = "AsteroidUpdateTestName",
                    DistToSun = 1.0f,
                    Weight = 2.0f,
                    Diametr = 3.0f,
                    Speed = 4.0f
                };

                await _repository.InsertAsync(asteroid);
                await _repository.SaveAsync();

                var spaceObject = await _repository.GetAsync(40);
                asteroid = (Asteroid)spaceObject;
                asteroid.Name = "AsteroidChangeTestName";
                var actualResponse = await _controller.Update(asteroid);
                var codeResponse = (StatusCodeResult)actualResponse;
                var expectedAsteroid = await _repository.GetAsync(40);

                Assert.AreEqual(expectedAsteroid.Name, asteroid.Name);
                Assert.AreEqual(200, codeResponse.StatusCode);
            }

            [Test]
            public async Task Update_AteroidNotFound_ShouldReturnNotFound()
            {
                var asteroid = new Asteroid()
                {
                    Id = 50,
                    Name = "Asteroid",
                    DistToSun = 1,
                    Weight = 2,
                    Diametr = 3,
                    Speed = 4
                };             

                var actualResponse = await _controller.Update(asteroid);
                var statusCodeResponse = (StatusCodeResult)actualResponse;
                var expectedAsteroid = await _repository.GetAsync(50);

                Assert.IsNull(expectedAsteroid);
                Assert.AreEqual(404, statusCodeResponse.StatusCode);
            }

            [Test]
            public async Task Delete_ShouldDeleteAsteroidAndReturnOK()
            {
                var asteroid = new Asteroid()
                {
                    Id = 60,
                    Name = "AsteroidDeleteTest",
                    DistToSun = 1.0f,
                    Weight = 2.0f,
                    Diametr = 3.0f,
                    Speed = 4.0f
                };

                await _repository.InsertAsync(asteroid);
                await _repository.SaveAsync();
                var expectedAsteroid = await _repository.GetAsync(60);

                Assert.IsNotNull(expectedAsteroid);
                Assert.AreEqual(expectedAsteroid.Name, "AsteroidDeleteTest");

                var actualResponse = await _controller.Delete(60);
                var codeResponse = (StatusCodeResult)actualResponse;
                expectedAsteroid = await _repository.GetAsync(60);

                Assert.IsNull(expectedAsteroid);
                Assert.AreEqual(204, codeResponse.StatusCode);
            }

            [Test]
            public async Task Delete_SendRequestWithFakeName_ShouldReturnNotFound()
            {
                var expectedAsteroid = await _repository.GetAsync(101);

                Assert.IsNull(expectedAsteroid);

                var actualResponse = await _controller.Delete(101);
                var statusCodeResponse = (StatusCodeResult)actualResponse;

                Assert.AreEqual(404, statusCodeResponse.StatusCode);
            }
        }
    }
}
