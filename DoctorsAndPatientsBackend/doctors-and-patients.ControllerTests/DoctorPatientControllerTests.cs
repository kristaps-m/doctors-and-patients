using doctors_and_patients.Controllers;
using doctors_and_patients.Core;
using doctors_and_patients.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;

namespace doctors_and_patients.ControllerTests
{
    public class DoctorPatientControllerTests
    {
        private AutoMocker _mocker;
        private Mock<IDoctorPatientService> _doctorPatientServiceMock;
        private DoctorPatientController _doctorPatientController;

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();
            _doctorPatientServiceMock = _mocker.GetMock<IDoctorPatientService>();
            _doctorPatientController = new DoctorPatientController(_doctorPatientServiceMock.Object);
        }

        [Test]
        public void AddDoctorPatient_TestControllerAbilityToAddDoctorPatient_ResultIsNotNull()
        {
            // Arrange
            var doctorPatient = new DoctorPatient() { Id = 1, DoctorId = 1, PatientId = 1};
            // Act
            var result = _doctorPatientController.AddDoctorPatient(doctorPatient);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<CreatedResult>(result);
        }

        [Test]
        public void DeleteDoctorPatient_TestControllerAbilityTDeleteDoctorPatient_ReturnsExpectedMessage()
        {
            // Arrange
            var doctorPatientId = 1;
            var doctorPatient = new DoctorPatient() { Id = 1, DoctorId = 1, PatientId = 1 };
            // Act
            var addResult = _doctorPatientController.AddDoctorPatient(doctorPatient);
            var deleteResult = _doctorPatientController.DeleteDoctorPatient(doctorPatientId) as OkObjectResult;
            // Assert
            Assert.IsNotNull(addResult);
            Assert.AreEqual("DoctorPatient with id 1 was deleted!", deleteResult.Value);
        }

        [Test]
        public void UpdateDoctorPatient_TestControllerAbilityToUpdateDoctorPatient_ResultIsNotNull()
        {
            // Arrange
            var doctorPatient = new DoctorPatient() { Id = 1, DoctorId = 1, PatientId = 1 };
            var doctorPatientUpdated = new DoctorPatient() { Id = 1, DoctorId = 1, PatientId = 2 };
            // Act
            _doctorPatientController.AddDoctorPatient(doctorPatient);
            var result = _doctorPatientController.UpdateDoctorPatient(doctorPatientUpdated, 1);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<CreatedResult>(result);
        }

        [Test]
        public void GetAllDoctorPatients_TestControllerAbilityToGetAllDoctorPatients_ResultIsNotNull_And_OkObjectResult()
        {
            // Arrange
            var doctorPatient1 = new DoctorPatient() { Id = 1, DoctorId = 1, PatientId = 1 };
            var doctorPatient2 = new DoctorPatient() { Id = 2, DoctorId = 1, PatientId = 1 };
            var doctorPatient3 = new DoctorPatient() { Id = 3, DoctorId = 1, PatientId = 1 };
            var doctorPatient4 = new DoctorPatient() { Id = 5, DoctorId = 2, PatientId = 22 };
            var doctorPatient5 = new DoctorPatient() { Id = 6, DoctorId = 2, PatientId = 22 };

            _doctorPatientController.AddDoctorPatient(doctorPatient1);
            _doctorPatientController.AddDoctorPatient(doctorPatient2);
            _doctorPatientController.AddDoctorPatient(doctorPatient3);
            _doctorPatientController.AddDoctorPatient(doctorPatient4);
            _doctorPatientController.AddDoctorPatient(doctorPatient5);
            // Act
            var result = _doctorPatientController.GetAllDoctorPatients();
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}
