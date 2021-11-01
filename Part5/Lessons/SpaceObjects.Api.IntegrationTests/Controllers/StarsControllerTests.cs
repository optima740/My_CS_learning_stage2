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
    class StarsControllerTests
    {
        [TestFixture]
        public class StarsControllerTest
        {
            private StarsController _controller;           
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
                _controller = new StarsController(_repository, _mapper);
            }

            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                Utilities.ReinitializeDbTest(_context);
            }

            [Test]
            public async Task GetAll_ShouldReturnOKAndStars()
            {
                var star = new Star()
                {
                    Id = 10,
                    Name = "NewStar",
                    DistToSun = 1.0f,
                    Weight = 2.0f,
                    Diametr = 3.0f,
                    DegOfIllumination = 4.0f
                };

                await _repository.InsertAsync(star);
                await _repository.SaveAsync();

                var actualResponse = _controller.GetAll();
                var expectedStars = _repository.GetAllByTypeAsync<Star>();
                var objResponse = (OkObjectResult)actualResponse.Result;

                Assert.AreEqual(expectedStars, objResponse.Value);
                Assert.AreEqual(200, objResponse.StatusCode);
            }

            [Test]
            public async Task GetAll_NotFound_ShouldReturnNotFound()
            {
                var stars = _repository.GetAllByTypeAsync<Star>();

                await foreach (var star in stars)
                {
                    await _repository.DeleteAsync(star.Id);
                }

                await _repository.SaveAsync();
                stars = _repository.GetAllByTypeAsync<Star>();
                var actualResponse = _controller.GetAll();
                var objResponse = (ObjectResult)actualResponse.Result;

                Assert.AreEqual(200, objResponse.StatusCode);
                Assert.AreEqual(stars, objResponse.Value);
            }

            [Test]
            public async Task Get_SendRequestWithName_ShouldReturnOkAndStar()
            {
                var star = new Star()
                {
                    Id = 20,
                    Name = "NewStar",
                    DistToSun = 1.0f,
                    Weight = 2.0f,
                    Diametr = 3.0f,
                    DegOfIllumination = 4.0f
                };

                await _repository.InsertAsync(star);
                await _repository.SaveAsync();

                var actualResponse = await _controller.Get(20);
                var expectedStar = await _repository.GetAsync(20);
                var objResponse = (ObjectResult)actualResponse.Result;

                Assert.AreEqual(expectedStar, objResponse.Value);
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
            public async Task Create_ShouldCreatedAndInsertStarAndReturnOK()
            {
                var star = new StarDto() 
                { 
                    Name = "StarCreateTest",
                    DistToSun = 1.0f,
                    Weight = 2.0f,
                    Diametr = 3.0f,
                    DegOfIllumination = 4.0f 
                };

                var actualResponse = await _controller.Create(star);
                var codeResponse = (StatusCodeResult)actualResponse;
                Assert.AreEqual(201, codeResponse.StatusCode);
            }

            [Test]
            public async Task Update_ShouldUpdateStarAndReturnOK()
            {
                var star = new Star()
                {
                    Id = 40,
                    Name = "StarUpdateTest",
                    DistToSun = 1.0f,
                    Weight = 2.0f,
                    Diametr = 3.0f,
                    DegOfIllumination = 4.0f
                };

                await _repository.InsertAsync(star);
                await _repository.SaveAsync();
                var spaceObject = await _repository.GetAsync(40);
                star = (Star)spaceObject;
                star.Name = "StarChangeTestName";
                var actualResponse = await _controller.Update(star);
                var codeResponse = (StatusCodeResult)actualResponse;
                var expectedStar = await _repository.GetAsync(40);

                Assert.AreEqual(expectedStar.Name, star.Name);
                Assert.AreEqual(200, codeResponse.StatusCode);
            }

            [Test]
            public async Task Update_StarNotFound_ShouldReturnNotFound()
            {
                var star = new Star()
                {
                    Id = 50,
                    Name = "Star",
                    DistToSun = 1.0f,
                    Weight = 2.0f,
                    Diametr = 3.0f,
                    DegOfIllumination = 4.0f
                };

                var actualResponse = await _controller.Update(star);
                var statusCodeResponse = (StatusCodeResult)actualResponse;
                var expectedStar = await _repository.GetAsync(50);

                Assert.IsNull(expectedStar);
                Assert.AreEqual(404, statusCodeResponse.StatusCode);
            }

            [Test]
            public async Task Delete_ShouldDeleteStarAndReturnOK()
            {
                var star = new Star()
                {
                    Id = 60,
                    Name = "StarDeleteTest",
                    DistToSun = 1.0f,
                    Weight = 2.0f,
                    Diametr = 3.0f,
                    DegOfIllumination = 4.0f
                };

                await _repository.InsertAsync(star);
                await _repository.SaveAsync();
                var expectedStar = await _repository.GetAsync(60);

                Assert.IsNotNull(expectedStar);
                Assert.AreEqual(expectedStar.Name, "StarDeleteTest");

                var actualResponse = await _controller.Delete(60);
                var codeResponse = (StatusCodeResult)actualResponse;
                expectedStar = await _repository.GetAsync(60);

                Assert.IsNull(expectedStar);
                Assert.AreEqual(204, codeResponse.StatusCode);
            }

            [Test]
            public async Task Delete_SendRequestWithFakeName_ShouldReturnNotFound()
            {
                var expectedStar = await _repository.GetAsync(101);

                Assert.IsNull(expectedStar);

                var actualResponse = await _controller.Delete(101);
                var statusCodeResponse = (StatusCodeResult)actualResponse;

                Assert.AreEqual(404, statusCodeResponse.StatusCode);
            }
        }
    }
}
