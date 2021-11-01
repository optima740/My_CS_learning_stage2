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
    class PlanetsControllerTests
    {
        [TestFixture]
        public class PlanetsControllerTest
        {
            private PlanetsController _controller;           
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
                _controller = new PlanetsController(_repository, _mapper);
            }

            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                Utilities.ReinitializeDbTest(_context);
            }

            [Test]
            public async Task GetAll_ShouldReturnOKAndPlanets()
            {
                var planet = new Planet()
                {
                    Id = 10,
                    Name = "NewPlanet",
                    DistToSun = 1.0f,
                    Weight = 2.0f,
                    Diametr = 3.0f,
                    TiltAngle = 4.0f
                };

                await _repository.InsertAsync(planet);
                await _repository.SaveAsync();

                var actualResponse = _controller.GetAll();
                var expectedPlanets = _repository.GetAllByTypeAsync<Planet>();
                var objResponse = (OkObjectResult)actualResponse.Result;

                Assert.AreEqual(expectedPlanets, objResponse.Value);
                Assert.AreEqual(200, objResponse.StatusCode);
            }

            [Test]
            public async Task GetAll_NotFound_ShouldReturnNotFound()
            {
                var planets = _repository.GetAllByTypeAsync<Planet>();

                await foreach (var planet in planets)
                {
                    await _repository.DeleteAsync(planet.Id);
                }

                await _repository.SaveAsync();
                planets = _repository.GetAllByTypeAsync<Planet>();
                var actualResponse = _controller.GetAll();
                var objResponse = (ObjectResult)actualResponse.Result;

                Assert.AreEqual(200, objResponse.StatusCode);
                Assert.AreEqual(planets, objResponse.Value);
            }

            [Test]
            public async Task Get_SendRequestWithName_ShouldReturnOkAndPlanet()
            {
                var planet = new Planet()
                {
                    Id = 20,
                    Name = "NewPlanet",
                    DistToSun = 1.0f,
                    Weight = 2.0f,
                    Diametr = 3.0f,
                    TiltAngle = 4.0f
                };

                await _repository.InsertAsync(planet);
                await _repository.SaveAsync();

                var actualResponse = await _controller.Get(20);
                var expectedPlanet = await _repository.GetAsync(20);
                var objResponse = (ObjectResult)actualResponse.Result;

                Assert.AreEqual(expectedPlanet, objResponse.Value);
                Assert.AreEqual(200, objResponse.StatusCode);
            }

            [Test]
            public async Task Get_SendRequestWithFakeName_ShouldReturnNotFound()
            {
                var actualResponse = await _controller.Get(20);
                var codeResponse = (StatusCodeResult)actualResponse.Result;

                Assert.AreEqual(404, codeResponse.StatusCode);
            }

            [Test]
            public async Task Create_ShouldCreatedAndInsertPlanetAndReturnOK()
            {
                var planet = new PlanetDto() 
                { 
                    Name = "PlanetCreateTest",
                    DistToSun = 1.0f,
                    Weight = 2.0f,
                    Diametr = 3.0f,
                    TiltAngle = 4.0f 
                };

                var actualResponse = await _controller.Create(planet);
                var codeResponse = (StatusCodeResult)actualResponse;
 
                Assert.AreEqual(201, codeResponse.StatusCode);
            }

            [Test]
            public async Task Update_ShouldUpdatePlanetAndReturnOK()
            {
                var planet = new Planet()
                {
                    Id = 40,
                    Name = "PlanetUpdateTest",
                    DistToSun = 1.0f,
                    Weight = 2.0f,
                    Diametr = 3.0f,
                    TiltAngle = 4.0f
                };

                await _repository.InsertAsync(planet);
                await _repository.SaveAsync();
                var spaceObject = await _repository.GetAsync(40);
                planet = (Planet)spaceObject;
                planet.Name = "PlanetChangeTestName";

                var actualResponse = await _controller.Update(planet);
                var codeResponse = (StatusCodeResult)actualResponse;
                var expectedPlanet = await _repository.GetAsync(40);

                Assert.AreEqual(expectedPlanet.Name, planet.Name);
                Assert.AreEqual(200, codeResponse.StatusCode);
            }

            [Test]
            public async Task Update_SendRequestWithInvalidData_ShouldReturnBadRequest()
            {
                var planet = new Planet()
                {
                    Id = 50,
                    Name = "Planet",
                    DistToSun = 1.0f,
                    Weight = 2.0f,
                    Diametr = 3.0f,
                    TiltAngle = 4.0f
                };

                var actualResponse = await _controller.Update(planet);
                var statusCodeResponse = (StatusCodeResult)actualResponse;
                var expectedPlanet = await _repository.GetAsync(50);

                Assert.IsNull(expectedPlanet);
                Assert.AreEqual(404, statusCodeResponse.StatusCode);
            }

            [Test]
            public async Task Delete_ShouldDeletePlanetAndReturnOK()
            {
                var planet = new Planet()
                {
                    Id = 60,
                    Name = "PlanetDeleteTest",
                    DistToSun = 1.0f,
                    Weight = 2.0f,
                    Diametr = 3.0f,
                    TiltAngle = 4.0f
                };

                await _repository.InsertAsync(planet);
                await _repository.SaveAsync();
                var expectedPlanet = await _repository.GetAsync(60);

                Assert.IsNotNull(expectedPlanet);
                Assert.AreEqual(expectedPlanet.Name, "PlanetDeleteTest");

                var actualResponse = await _controller.Delete(60);
                var codeResponse = (StatusCodeResult)actualResponse;
                expectedPlanet = await _repository.GetAsync(60);

                Assert.IsNull(expectedPlanet);
                Assert.AreEqual(204, codeResponse.StatusCode);
            }

            [Test]
            public async Task Delete_SendRequestWithFakeName_ShouldReturnNotFound()
            {
                var expectedPlanet = await _repository.GetAsync(101);

                Assert.IsNull(expectedPlanet);

                var actualResponse = await _controller.Delete(101);
                var statusCodeResponse = (StatusCodeResult)actualResponse;

                Assert.AreEqual(404, statusCodeResponse.StatusCode);
            }
        }
    }
}
