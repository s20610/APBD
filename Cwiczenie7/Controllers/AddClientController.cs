using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cwiczenie7.Service;

namespace Cwiczenie7.Controllers
{
    [ApiController]
    [Route("api/trip")]
    public class AddClientController : Controller
    {
        private readonly IDBService _iDBService;

        public AddClientController(IDBService dBService)
        {
            _iDBService = dBService;
        }

        [HttpPost("{idTrip}/clients")]
        
        public async Task<IActionResult> AddClientToTrip(int id)
        {
            var status = _iDBService.AddClientToTrip(id);
            if (status.Equals("Error"))
                return BadRequest();
            return Ok();
        }
    }
}