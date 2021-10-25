using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cwiczenie7.Service;

namespace Cwiczenie7.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : Controller
    {
        private readonly IDBService _iDBService;

        public ClientsController(IDBService dBService)
        {
            _iDBService = dBService;
        }

        [HttpDelete("{idClient}")]

        public async Task<IActionResult> DeleteClientFromDB(int idClient)
        {
            var status = _iDBService.DeleteClientFromDB(idClient);
            if (status.Equals("Error"))
                return BadRequest();
            return Ok();
        }

        public async Task<IActionResult> AddClientToTrip(int id)
        {
            var status = _iDBService.AddClientToTrip(id);
            if (status.Equals("Error"))
                return BadRequest();
            return Ok();
        }
    }
}
