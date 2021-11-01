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
    class BlackHolesControllerTests
    {
        [TestFixture]
        public class BlackHolesControllerTest
        {
            private BlackHolesController _controller;           
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
                _controller = new BlackHolesController(_repository, _mapper);
                
            }

            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                Utilities.ReinitializeDbTest(_context);
            }

            [Test]
            public async Task GetAll_ShouldReturnOKAndBlackHoles()
            {
                var blackHole = new BlackHole()
                {
                    Id = 10,
                    Name = "NewBlackHole",
                    DistToSun = 1.0f,
                    Weight = 2.0f,
                    Diametr = 3.0f,
                    Density = 4.0f
                };

                await _repository.InsertAsync(blackHole);
                await _repository.SaveAsync();

                var actualResponse = _controller.GetAll();
                var expectedBlackHoles = _repository.GetAllByTypeAsync<BlackHole>();
                var objResponse = (OkObjectResult)actualResponse.Result;

                Assert.AreEqual(expectedBlackHoles, objResponse.Value);
                Assert.AreEqual(200, objResponse.StatusCode);
            }

            [Test]
            public async Task GetAll_NotFound_ShouldReturnNotFound()
            {
                var blackHoles = _repository.GetAllByTypeAsync<BlackHole>();

                await foreach (var blackHole in blackHoles)
                {
                    await _repository.DeleteAsync(blackHole.Id);
                }

                await _repository.SaveAsync();
                blackHoles = _repository.GetAllByTypeAsync<BlackHole>();
                var actualResponse = _controller.GetAll();
                var objResponse = (ObjectResult)actualResponse.Result;

                Assert.AreEqual(200, objResponse.StatusCode);
                Assert.AreEqual(blackHoles, objResponse.Value);
            }

            [Test]
            public async Task Get_SendRequestWithName_ShouldReturnOkAndBlackHole()
            {
                var blackHole = new BlackHole()
                {
                    Id = 20,
                    Name = "NewBlackHole",
                    DistToSun = 1.0f,
                    Weight = 2.0f,
                    Diametr = 3.0f,
                    Density = 4.0f
                };

                await _repository.InsertAsync(blackHole);
                await _repository.SaveAsync();

                var actualResponse = await _controller.Get(20);
                var expectedBlackHole = await _repository.GetAsync(20);
                var objResponse = (ObjectResult)actualResponse.Result;

                Assert.AreEqual(expectedBlackHole, objResponse.Value);
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
            public async Task Create_ShouldCreatedAndInsertBlackHoleAndReturnOK()
            {
                var blackHole = new BlackHoleDto() 
                { 
                    Name = "BlackHoleCreateTest",
                    DistToSun = 1.0f,
                    Weight = 2.0f,
                    Diametr = 3.0f,
                    Density = 4.0f 
                };

                var actualResponse = await _controller.Create(blackHole);
                var codeResponse = (StatusCodeResult)actualResponse;

                Assert.AreEqual(201, codeResponse.StatusCode);
            }

            [Test]
            public async Task Update_ShouldUpdateBlackHoleAndReturnOK()
            {
                var blackHole = new BlackHole()
                {
                    Id = 40,
                    Name = "BlackHoleUpdateTest",
                    DistToSun = 1.0f,
                    Weight = 2.0f,
                    Diametr = 3.0f,
                    Density = 4.0f
                };

                await _repository.InsertAsync(blackHole);
                await _repository.SaveAsync();

                var spaceObject = await _repository.GetAsync(40);
                blackHole = (BlackHole)spaceObject;
                blackHole.Name = "BlackHoleChangeTestName";
                var actualResponse = await _controller.Update(blackHole);
                var codeResponse = (StatusCodeResult)actualResponse;
                var expectedBlackHole = await _repository.GetAsync(40);

                Assert.AreEqual(expectedBlackHole.Name, blackHole.Name);
                Assert.AreEqual(200, codeResponse.StatusCode);
            }

            [Test]
            public async Task Update_BlackHoleNotFound_ShouldReturnNotFound()
            {
                var blackHole = new BlackHole()
                {
                    Id = 50,
                    Name = "BlackHole",
                    DistToSun = 1.0f,
                    Weight = 2.0f,
                    Diametr = 3.0f,
                    Density = 4.0f
                };

                var actualResponse = await _controller.Update(blackHole);
                var statusCodeResponse = (StatusCodeResult)actualResponse;
                var expectedBlackHole = await _repository.GetAsync(50);

                Assert.IsNull(expectedBlackHole);
                Assert.AreEqual(404, statusCodeResponse.StatusCode);
            }

            [Test]
            public async Task Delete_ShouldDeleteBlackHoleAndReturnOK()
            {
                var blackHole = new BlackHole()
                {
                    Id = 60,
                    Name = "BlackHoleDeleteTest",
                    DistToSun = 1.0f,
                    Weight = 2.0f,
                    Diametr = 3.0f,
                    Density = 4.0f
                };

                await _repository.InsertAsync(blackHole);
                await _repository.SaveAsync();
                var expectedBlackHole = await _repository.GetAsync(60);

                Assert.IsNotNull(expectedBlackHole);
                Assert.AreEqual(expectedBlackHole.Name, "BlackHoleDeleteTest");

                var actualResponse = await _controller.Delete(60);
                var codeResponse = (StatusCodeResult)actualResponse;
                expectedBlackHole = await _repository.GetAsync(60);

                Assert.IsNull(expectedBlackHole);
                Assert.AreEqual(204, codeResponse.StatusCode);
            }

            [Test]
            public async Task Delete_SendRequestWithFakeName_ShouldReturnNotFound()
            {
                var expectedBlackHole = await _repository.GetAsync(101);

                Assert.IsNull(expectedBlackHole);

                var actualResponse = await _controller.Delete(101);
                var statusCodeResponse = (StatusCodeResult)actualResponse;

                Assert.AreEqual(404, statusCodeResponse.StatusCode);
            }
        }
    }
}
