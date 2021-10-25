using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using APDB08.DAL;
using APDB08.Model;
using Microsoft.AspNetCore.Authorization;

namespace APDB08.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalController : ControllerBase
    {

        private readonly HospitalContext _hospitalContext;

        public HospitalController(HospitalContext hospitalContext)
        {
            _hospitalContext = hospitalContext;
        }

        [Authorize]
        [HttpGet("doctors/{idDoctor}")]
        public IActionResult GetDoctor(int idDoctor)
        {
            try
            {
                var res = _hospitalContext.Doctor
                    .Where(d => d.IdDoctor == idDoctor).ToList();
                return Ok(res.First());
            } catch (Exception e) { return BadRequest(e); }
        }

        [Authorize]
        [HttpPost("doctors")]
        public IActionResult AddDoctor(Doctor doctor)
        {
            Doctor newDoctor = new Doctor
            {
                Email = doctor.Email,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
            };
            _hospitalContext.Add(newDoctor);
            _hospitalContext.SaveChanges();
            return Ok();
        }

        [Authorize]
        [HttpPut("doctors")]
        public IActionResult UpdateDoctor(Doctor doctor)
        {
            try
            {
                var res = _hospitalContext.Doctor
                    .Where(d => d.IdDoctor == doctor.IdDoctor)
                    .ToList();
                Doctor oldDoctor = res.First();
                oldDoctor.FirstName = doctor.FirstName;
                oldDoctor.LastName = doctor.LastName;
                oldDoctor.Email = doctor.Email;
                _hospitalContext.Update(oldDoctor);
                _hospitalContext.SaveChanges();
                return Ok(doctor.IdDoctor + " successfully modified");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpDelete("doctors/delete/{idDoctor}")]
        public IActionResult DeleteDoctor(int idDoctor)
        {
            try
            {
                var res = _hospitalContext.Doctor
                    .Where(d => d.IdDoctor == idDoctor).ToList();
                _hospitalContext.Doctor.Remove(res.First());
                _hospitalContext.SaveChanges();
                return Ok(idDoctor + " successfully deleted");
            }
            catch (Exception e) { return BadRequest(e); }
        }

        [Authorize]
        [HttpGet("prescription/{idPatient}/{idDoctor}/{idMedicament}")]
        public IActionResult GetPrescription(int idPatient, int idDoctor, int idMedicament)
        {
            try{
                var res = _hospitalContext.Prescription.Where(pres => pres.IdPatient.Equals(idPatient) && pres.IdDoctor.Equals(idDoctor)).ToList();
                return Ok(res.First());
            } catch (Exception e) { return BadRequest(e); }
        }
    }
}