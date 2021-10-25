using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cwiczenie4.Models;
using Cwiczenie4.Services;
using Cwiczenie4.Services.Exceptions;

namespace Cwiczenie4.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IDataService DataService;

        public AnimalsController(IDataService DataService)
        {
            this.DataService = DataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimals([FromQuery] string orderBy)
        {
            List<Animal> animals = null;
            try { animals = DataService.GetAnimals(orderBy); }
            catch (DataNoRowsException) { return NotFound("No rows in db"); }
            catch (NotMatchedColumnNameException) { return BadRequest("You can order by name, description, category or area"); }
            return Ok(animals);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnimal([FromBody] Animal animal)
        {
            try { DataService.CreateAnimal(animal); }
            catch (Exception) { return BadRequest("data is not valid"); }
            return Ok("Succsesfully created");
        }

        [HttpPut("{idAnimal}")]
        public async Task<IActionResult> ChangeAnimal([FromRoute] int idAnimal, [FromBody] Animal animal)
        {
            try { DataService.ChangeAnimal(idAnimal, animal); }
            catch (NoExecutedQueryException) { return NotFound($"No such animal found with ID {idAnimal}"); }
            catch  (Exception) { return BadRequest("data is not valid");  }
            return Ok("Succsesfully changed");
        }

        [HttpDelete("{idAnimal}")]
        public async Task<IActionResult> DeleteAnimal([FromRoute] int idAnimal)
        {
            try { DataService.DeleteAnimal(idAnimal); }
            catch (NoExecutedQueryException) { return NotFound($"No such animal found with ID {idAnimal}"); }
            catch (Exception) { return BadRequest("data is not valid"); }
            return Ok("Succsesfully deleted");
        }


    }
}