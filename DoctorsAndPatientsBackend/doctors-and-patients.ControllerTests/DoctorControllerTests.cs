using doctors_and_patients.Controllers;
using doctors_and_patients.Core;
using doctors_and_patients.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;

namespace doctors_and_patients.ControllerTests
{
    public class DoctorControllerTests
    {
        private AutoMocker _mocker;
        private Mock<IDoctorService> _doctorServiceMock;
        private DoctorController _doctorController;

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();
            _doctorServiceMock = _mocker.GetMock<IDoctorService>();
            _doctorController = new DoctorController(_doctorServiceMock.Object);
        }

        [Test]
        public void AddDoctor_TestControllerAbilityToAddDoctor_ResultIsNotNull()
        {            
            // Arrange
            var doctor = new Doctor() {Name = "Kristaps", LastName = "Ozols" };
            // Act
            var result = _doctorController.AddDoctor(doctor);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<CreatedResult>(result);
        }

        [Test]
        public void DeleteDoctor_TestControllerAbilityToDeleteDoctor_ReturnsExpectedMessage()
        {
            // Arrange
            var doctorId = 1;
            var doctor = new Doctor { Id = doctorId, Name = "Kristaps", LastName = "Ozols" };
            // Act
            var addResult = _doctorController.AddDoctor(doctor);
            var deleteResult = _doctorController.DeleteDoctor(doctorId) as OkObjectResult;
            // Assert
            Assert.IsNotNull(addResult);
            Assert.AreEqual("Doctor with id 1 was deleted!", deleteResult.Value);
        }

        [Test]
        public void UpdateDoctor_TestControllerAbilityToUpdateDoctor_ResultIsNotNull()
        {
            // Arrange
            var doctor = new Doctor() {Id = 1, Name = "Kristaps", LastName = "Ozols" };
            var doctorUpdated = new Doctor() { Id = 1, Name = "Newname", LastName = "Ozols" };
            // Act
            _doctorController.AddDoctor(doctor);
            var result = _doctorController.UpdateDoctor(doctorUpdated, 1);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<CreatedResult>(result);
        }

        [Test]
        public void GetOneDoctor_TestControllerAbilityToGetOneDoctor_ResultIsNotNull()
        {
            // Arrange
            var doctor = new Doctor() { Id = 1, Name = "Kristaps", LastName = "Ozols" };
            // Act
            _doctorController.AddDoctor(doctor);
            var result = _doctorController.GetOneDoctor(1);
            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetOneDoctor_TestControllerAbilityToGetOneDoctor_ResultIsNotFound()
        {
            // Arrange
            var doctor = new Doctor() { Id = 1, Name = "Kristaps", LastName = "Ozols" };
            // Act
            _doctorController.AddDoctor(doctor);
            var result = _doctorController.GetOneDoctor(2);
            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void GetAllDoctors_TestControllerAbilityToGetAllDoctors_ResultIsNotNull_And_OkObjectResult()
        {
            // Arrange
            var doctor1 = new Doctor() { Id = 1, Name = "Kristaps", LastName = "Ozols" };
            var doctor2 = new Doctor() { Id = 2, Name = "B", LastName = "Ozols" };
            var doctor3 = new Doctor() { Id = 3, Name = "C", LastName = "Ozols" };
            var doctor4 = new Doctor() { Id = 4, Name = "D", LastName = "Ozols" };
            var doctor5 = new Doctor() { Id = 5, Name = "E", LastName = "Ozols" };
            
            _doctorController.AddDoctor(doctor1);
            _doctorController.AddDoctor(doctor2);
            _doctorController.AddDoctor(doctor3);
            _doctorController.AddDoctor(doctor4);
            _doctorController.AddDoctor(doctor5);
            // Act
            var result = _doctorController.GetAllDoctors();
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
        } 
    }
}