﻿using doctors_and_patients.Core;
using doctors_and_patients.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace doctors_and_patients.Controllers
{
    [Route("api/[controller]")]
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
			var doctorToUpdate = _doctorService.GetById(id);
			doctorToUpdate.Name = doctor.Name;
			doctorToUpdate.LastName = doctor.LastName;
			_doctorService.Update(doctorToUpdate);

			return Created("", doctorToUpdate);
		}

		[Route("delete/{id}")]
		[HttpDelete]
		public IActionResult DeleteDoctor(int id)
		{
			var doctorToDelete = _doctorService.GetById(id);
			_doctorService.Delete(doctorToDelete);

			return Ok($"Doctor with id {id} was deleted!");
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