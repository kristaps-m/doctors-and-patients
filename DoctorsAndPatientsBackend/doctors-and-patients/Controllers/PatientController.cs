using doctors_and_patients.Core;
using doctors_and_patients.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace doctors_and_patients.Controllers
{
    [Route("api/patient")]
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

		[Route("add/doctorid/{doctorId}")]
		[HttpPost]
		public IActionResult AddPatientAndDoctorPatient(Patient patient, int doctorId)
		{
			_patientService.CreatePatientAndDoctorPatient(patient,doctorId);

			return Created($"Patient with doctor Id {doctorId} created!", patient);
		}


		[Route("update")]
		[HttpPut]
		public IActionResult UpdatePatient(Patient patient, int id)
		{
			var patientToUpdate = _patientService.UpdateOnePatient(patient, id);

			return Created("", patientToUpdate);
		}

		[Route("delete/{id}")]
		[HttpDelete]
		public IActionResult DeletePatient(int id)
		{
			_patientService.DeleteOnePatient(id);

			return Ok($"Patient with id {id} was deleted!");
		}

		[Route("all")]
		[HttpGet]
		public IActionResult GetAllPatients()
		{
			var patients = _patientService.GetAll();

			return Ok(patients);
		}

		[Route("doctor/{id}")]
		[HttpGet]
		public IActionResult GetAllSpecialPatients(int id)
		{
			var specialPatientsByDoctorId = _patientService.GetAllSpecialPatientsByDoctorId(id);

			return Ok(specialPatientsByDoctorId);
		}
	}
}
