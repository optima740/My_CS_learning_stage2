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
    public class PlanetsController : ControllerBase
    {
        private readonly ISpaceObjectRepository _repository;
        private readonly IMapper _mapper;

        public PlanetsController(ISpaceObjectRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IAsyncEnumerable<Planet>> GetAll()
        {
            var planets = _repository.GetAllByTypeAsync<Planet>();
            
            return Ok(planets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Planet>> Get(int id)
        {
            var planet = await _repository.GetAsync(id);
            return (planet != null) ? Ok(planet) : StatusCode(404);
        }

        [HttpPost]     
        public async Task<ActionResult> Create([FromBody] PlanetDto planet)
        {

            var model = _mapper.Map<Planet>(planet);
            await _repository.InsertAsync(model);
            await _repository.SaveAsync();
            
            return StatusCode(201);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Planet planet)
        {

            if (await _repository.UpdateAsync(planet))
            {
                await _repository.SaveAsync();
                
                return StatusCode(200);
            }

            return StatusCode(404);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var planet = await _repository.GetAsync(id);
            if (planet != null)
            {
                await _repository.DeleteAsync(planet.Id);
                await _repository.SaveAsync();

                return StatusCode(204);
            }

            return StatusCode(404);
        }
    }
}
