using doctors_and_patients.Core;
using doctors_and_patients.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace doctors_and_patients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
		private readonly IPatientService _patientService;

		public PatientController(IPatientService patientService)
		{
			_patientService = patientService;
		}

		[Route("add")]
		[HttpPost]
		public IActionResult AddPatient(Patient patient)
		{
			_patientService.Create(patient);

			return Created("", patient); 
		}

		[Route("update")]
		[HttpPut]
		public IActionResult UpdatePatient(Patient patient, int id)
		{
			var patientToUpdate = _patientService.GetById(id);
			patientToUpdate.Name = patient.Name;
			patientToUpdate.LastName = patient.LastName;
			patientToUpdate.DateOfBirth = patient.DateOfBirth;
			patientToUpdate.City = patient.City;
			_patientService.Update(patientToUpdate);

			return Created("", patientToUpdate);
		}

		[Route("delete/{id}")]
		[HttpDelete]
		public IActionResult DeletePatient(int id)
		{
			var patientToDelete = _patientService.GetById(id);
			_patientService.Delete(patientToDelete);

			return Ok($"Patient with id {id} was deleted!");
		}

		[Route("all")]
		[HttpGet]
		public IActionResult GetAllPatients()
		{
			var patients = _patientService.GetAll();

			return Ok(patients);
		}
	}
}
