using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cwiczenie7.Service;

namespace Cwiczenie7.Controllers
{
    [ApiController]
    [Route("api/trips")]
    public class TripsController : ControllerBase
    {
        private readonly IDBService idbService;

        public TripsController(IDBService dBService)
        {
            idbService = dBService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTripsFromDB() 
        {
            return Ok(await idbService.GetTripsFromDB());
        }

        [HttpPost("{idTrip}")]
        public async Task<IActionResult> AddClientToTrip(int id)
        {
            
            return Ok();
        }
    }
}
