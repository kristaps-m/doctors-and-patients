using doctors_and_patients.Controllers;
using doctors_and_patients.Core;
using doctors_and_patients.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;

namespace doctors_and_patients.ControllerTests
{
    public class PatientControllerTests
    {
        private AutoMocker _mocker;
        private Mock<IPatientService> _patientServiceMock;
        private Mock<IDoctorPatientService> _doctorPatientServiceMock;
        private PatientController _patientController;
        private DoctorPatientController _doctorPatientController;

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();
            _patientServiceMock = _mocker.GetMock<IPatientService>();
            _patientController = new PatientController(_patientServiceMock.Object);
            _doctorPatientServiceMock = _mocker.GetMock<IDoctorPatientService>();
            _doctorPatientController = new DoctorPatientController(_doctorPatientServiceMock.Object);
        }

        [Test]
        public void AddPatient_TestControllerAbilityToAddPatient_ResultIsNotNull()
        {
            // Arrange
            var patient = new Patient() { Name = "Madara", LastName = "Small", City = "Riga", DateOfBirth = new DateTime(2000,01,01) };
            // Act
            var result = _patientController.AddPatientAndDoctorPatient(patient, 1);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<CreatedResult>(result);
        }

        [Test]
        public void AddPatientAndDoctorPatient_TestControllerAbilityToAddPatientAndDoctorPatient_ResultIsNotNull()
        {
            // Arrange
            var patient = new Patient() { Name = "Madara", LastName = "Small", City = "Riga", DateOfBirth = new DateTime(2000, 01, 01) };
            // Act
            var result = _patientController.AddPatientAndDoctorPatient(patient, 1);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<CreatedResult>(result);
        }

        [Test]
        public void DeletePatient_TestControllerAbilityToDeletePatient_ReturnsExpectedMessage()
        {
            // Arrange
            var patientId = 1;
            var patient = new Patient() {Id = 1, Name = "Madara", LastName = "Small", City = "Riga", DateOfBirth = new DateTime(2000, 01, 01) };
            // Act
            var addResult = _patientController.AddPatient(patient);
            var deleteResult = _patientController.DeletePatient(patientId) as OkObjectResult;
            // Assert
            Assert.IsNotNull(addResult);
            Assert.AreEqual("Patient with id 1 was deleted!", deleteResult.Value);
        }

        [Test]
        public void UpdatePatient_TestControllerAbilityToUpdatePatient_ResultIsNotNull()
        {
            // Arrange
            var patient = new Patient() { Id = 1, Name = "Madara", LastName = "Small", City = "Riga", DateOfBirth = new DateTime(2000, 01, 01) };
            var patientUpdated = new Patient() { Id = 1, Name = "Newname", LastName = "B", City = "C", DateOfBirth = new DateTime(1999, 01, 01) };
            // Act
            _patientController.AddPatient(patient);
            var result = _patientController.UpdatePatient(patientUpdated, 1);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<CreatedResult>(result);
        }

        [Test]
        public void GetAllPatients_TestControllerAbilityToGetAllPatients_ResultIsNotNull_And_OkObjectResult()
        {
            // Arrange
            var patient1 = new Patient() { Id = 1, Name = "Madara", LastName = "Small", City = "Riga", DateOfBirth = new DateTime(2000, 01, 01) };
            var patient2 = new Patient() { Id = 2, Name = "B", LastName = "Small", City = "B", DateOfBirth = new DateTime(2000, 01, 01) };
            var patient3 = new Patient() { Id = 3, Name = "C", LastName = "Small", City = "C", DateOfBirth = new DateTime(2000, 01, 01) };


            _patientController.AddPatient(patient1);
            _patientController.AddPatient(patient2);
            _patientController.AddPatient(patient3);
            // Act
            var result = _patientController.GetAllPatients();
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void GetAllSpecialPatients_TestControllerAbilityToGetAllSpecialPatients_ResultIsNotNull_And_OkObjectResult()
        {
            // Arrange
            var patient1 = new Patient() { Id = 1, Name = "Madara", LastName = "Small", City = "Riga", DateOfBirth = new DateTime(2000, 01, 01) };
            var patient2 = new Patient() { Id = 2, Name = "B", LastName = "Small", City = "B", DateOfBirth = new DateTime(2000, 01, 01) };
            var patient3 = new Patient() { Id = 3, Name = "C", LastName = "Small", City = "C", DateOfBirth = new DateTime(2000, 01, 01) };
            var doctorPatient1 = new DoctorPatient() { Id = 1, DoctorId = 1, PatientId = 1 };
            var doctorPatient2 = new DoctorPatient() { Id = 2, DoctorId = 1, PatientId = 2 };

            _patientController.AddPatient(patient1);
            _patientController.AddPatient(patient2);
            _patientController.AddPatient(patient3);
            _doctorPatientController.AddDoctorPatient(doctorPatient1);
            _doctorPatientController.AddDoctorPatient(doctorPatient2);

            // Act
            var result = _patientController.GetAllSpecialPatients(1);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}
