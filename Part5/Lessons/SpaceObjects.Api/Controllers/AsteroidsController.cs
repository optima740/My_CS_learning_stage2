using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpaceObjects.Api.DataAccessLayer;
using SpaceObjects.Api.DTO;
using SpaceObjects.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceObjects.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsteroidsController : ControllerBase
    {
        private readonly ISpaceObjectRepository _repository;
        private readonly IMapper _mapper;

        public AsteroidsController(ISpaceObjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IAsyncEnumerable<Asteroid>> GetAll()
        {
            var asteroids = _repository.GetAllByTypeAsync<Asteroid>();
            
            return Ok(asteroids);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Asteroid>> Get(int id)
        {
            var asteroid = await _repository.GetAsync(id);
            
            return (asteroid != null)? Ok(asteroid): StatusCode(404);
        }

        [HttpPost]     
        public async Task<ActionResult> Create([FromBody] AsteroidDto asteroid)
        {
            var model = _mapper.Map<Asteroid>(asteroid);
           
            await _repository.InsertAsync(model);
            await _repository.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Asteroid asteroid)
        {
            
            if (await _repository.UpdateAsync(asteroid))
            {
                await _repository.SaveAsync();
                return StatusCode(200);
            }

            return StatusCode(404);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var asteroid = await _repository.GetAsync(id);
            if (asteroid != null)
            {
                await _repository.DeleteAsync(asteroid.Id);
                await _repository.SaveAsync();

                return StatusCode(204);
            }

            return StatusCode(404);
        }
    }
}
