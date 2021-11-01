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
    public class StarsController : ControllerBase
    {
        private readonly ISpaceObjectRepository _repository;
        private readonly IMapper _mapper;

        public StarsController(ISpaceObjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IAsyncEnumerable<Star>> GetAll()
        {
            var stars = _repository.GetAllByTypeAsync<Star>();
            
            return Ok(stars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Star>> Get(int id)
        {
            var star = await _repository.GetAsync(id);
            return (star != null) ? Ok(star) : StatusCode(404);
        }

        [HttpPost]     
        public async Task<ActionResult> Create([FromBody] StarDto star)
        {
            var model = _mapper.Map<Star>(star);
            await _repository.InsertAsync(model);
            await _repository.SaveAsync();
            
            return StatusCode(201);           
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Star star)
        {
           
            if (await _repository.UpdateAsync(star))
            {
                await _repository.SaveAsync();
                
                return StatusCode(200);
            }

            return StatusCode(404);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var star = await _repository.GetAsync(id);
            if (star != null)
            {
                await _repository.DeleteAsync(star.Id);
                await _repository.SaveAsync();

                return StatusCode(204);
            }

            return StatusCode(404);
        }
    }
}
