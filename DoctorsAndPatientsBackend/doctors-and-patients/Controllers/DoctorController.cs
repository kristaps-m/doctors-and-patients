using doctors_and_patients.Core;
using doctors_and_patients.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace doctors_and_patients.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

		[Route("add")]
		[HttpPost]
		public IActionResult AddDoctor(Doctor doctor)
		{
			_doctorService.Create(doctor);

			return Created("", doctor);
		}

		[Route("update")]
		[HttpPut]
		public IActionResult UpdateDoctor(Doctor doctor, int id)
		{
			var doctorToUpdate = _doctorService.UpdateOneDoctor(doctor,id);

			return Created("", doctorToUpdate);
		}

		[Route("delete/{id}")]
		[HttpDelete]
		public IActionResult DeleteDoctor(int id)
		{
			_doctorService.DeleteOneDoctor(id);

			return Ok($"Doctor with id {id} was deleted!");
		}

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetOneDoctor(int id)
        {
			var doctor = _doctorService.GetById(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

		[Route("all")]
		[HttpGet]
		public IActionResult GetAllDoctors()
		{
			var doctors = _doctorService.GetAll();

			return Ok(doctors);
		}
	}
}
