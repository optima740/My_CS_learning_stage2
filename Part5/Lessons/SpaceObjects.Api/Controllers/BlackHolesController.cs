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
    public class BlackHolesController : ControllerBase
    {
        private readonly ISpaceObjectRepository _repository;
        private readonly IMapper _mapper;

        public BlackHolesController(ISpaceObjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IAsyncEnumerable<BlackHole>> GetAll()
        {
            var blackHoles = _repository.GetAllByTypeAsync<BlackHole>();
            
            return Ok(blackHoles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlackHole>> Get(int id)
        {
            var blackHole = await _repository.GetAsync(id);
            
            return (blackHole != null)? Ok(blackHole): StatusCode(404);
        }

        [HttpPost]     
        public async Task<ActionResult> Create([FromBody] BlackHoleDto blackHole)
        {
            var model = _mapper.Map<BlackHole>(blackHole);

            await _repository.InsertAsync(model);
            await _repository.SaveAsync();           
            
            return StatusCode(201);
        }

        [HttpPut]
        public async Task<ActionResult> Update(BlackHole blackHole)
        {

            if (await _repository.UpdateAsync(blackHole))
            {
                await _repository.SaveAsync();
                
                return StatusCode(200);
            }

            return StatusCode(404);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var blackHole = await _repository.GetAsync(id);
            if (blackHole != null)
            {
                await _repository.DeleteAsync(blackHole.Id);
                await _repository.SaveAsync();

                return StatusCode(204);
            }

            return StatusCode(404);
        }
    }
}
