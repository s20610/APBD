using System.Threading.Tasks;
using Kolokwium.DTO.Requests;
using Kolokwium.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [ApiController]
    [Route("api/musician")]
    public class MusicianController : ControllerBase
    {
        private readonly IMusicianDbRepository _musicianDbRepository;

        public MusicianController(IMusicianDbRepository musicianDbRepository)
        {
            _musicianDbRepository = musicianDbRepository;
        }
        
        [HttpGet("{idMusician}")]
        public async Task<IActionResult> GetMusician([FromRoute] int idMusician)
        {
            var result = await _musicianDbRepository.GetMusician(idMusician);
            if (result == null)
                return NotFound("There is no musician with that id");
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> PostMusician([FromBody] MusicianRequestDTO musician)
        {
            var status =  await _musicianDbRepository.PostMusician(musician);
            return StatusCode(status.Code, status.Message);
        }
    }
}