using doctors_and_patients.Controllers;
using doctors_and_patients.Core;
using doctors_and_patients.Core.Interfaces;
using doctors_and_patients.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using System.Web.Http;
using System.Web.Http.Results;

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
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void AddDoctort_TestControllerAbilityToAddDoctor_ResultIsNotNull()
        {            
            // Arrange
            var doctor = new Doctor() {Name = "Kristaps", LastName = "Ozols" };
            // Act
            var result = _doctorController.AddDoctor(doctor);

            // Assert
            Assert.IsNotNull(result);
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
        public void AddDoctor_ReturnsCorrectObject()
        {
            // Arrange
            //var doctorRepositoryMock = new Mock<IDoctorRepository>();
            var expectedDoctor = new Doctor
            {
                Id = 1,
                Name = "Kristaps",
                LastName = "Pauris"
            };

            // Configure the doctor repository mock to return the expected doctor
            //doctorRepositoryMock
            //    .Setup(repo => repo.Add(It.IsAny<Doctor>()))
            //    .Returns(expectedDoctor);

            //var controller = new DoctorController(doctorRepositoryMock.Object);

            // Act
            //var result = controller.AddDoctor(expectedDoctor) as IHttpActionResult;
            var result = _doctorController.AddDoctor(expectedDoctor);

            // Assert
            //Assert.IsNotNull(result);
            //Assert.IsTrue(result is OkNegotiatedContentResult<Doctor>);
            var contentResult = result as OkNegotiatedContentResult<Doctor>;
            Assert.That(contentResult.Content, Is.EqualTo(expectedDoctor));
        }
    }
}