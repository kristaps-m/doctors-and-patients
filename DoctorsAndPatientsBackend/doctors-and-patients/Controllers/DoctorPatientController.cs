using doctors_and_patients.Core;
using doctors_and_patients.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace doctors_and_patients.Controllers
{
    [Route("api/doctorpatient")]
    [ApiController]
    public class DoctorPatientController : ControllerBase
    {
		private readonly IDoctorPatientService _doctorPatientService;

		public DoctorPatientController(IDoctorPatientService doctorPatientService)
		{
			_doctorPatientService = doctorPatientService;
		}

		[Route("add")]
		[HttpPost]
		public IActionResult AddDoctorPatient(DoctorPatient doctorPatient)
		{
			_doctorPatientService.Create(doctorPatient);

			return Created("", doctorPatient);
		}

		[Route("update")]
		[HttpPut]
		public IActionResult UpdateDoctorPatient(DoctorPatient doctorPatient, int id)
		{
			var doctorPatientToUpdate = _doctorPatientService.UpdateOneDoctorPatient(doctorPatient, id);

			return Created("", doctorPatientToUpdate);
		}

		[Route("delete/{id}")]
		[HttpDelete]
		public IActionResult DeleteDoctorPatient(int id)
		{
			_doctorPatientService.DeleteOneDoctorPatient(id);

			return Ok($"DoctorPatient with id {id} was deleted!");
		}

		[Route("all")]
		[HttpGet]
		public IActionResult GetAllDoctorPatients()
		{
			var doctorPatients = _doctorPatientService.GetAll();

			return Ok(doctorPatients);
		}
	}
}
