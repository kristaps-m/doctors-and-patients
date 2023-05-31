using doctors_and_patients.Core;
using doctors_and_patients.Core.Interfaces;
using doctors_and_patients.Data;
using doctors_and_patients.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace doctors_and_patients.ServicesTests
{
    public class PatientServiceTests
    {
        [Test] 
        public void GetAllSpecialPatientsByDoctorId_TestMethodAbilityToFilterByDoctorId_ReturnsTwoPatients()
        {
            // Arrange
            var doctorId = 1;

            var doctorPatientServiceMock = new Mock<IDoctorPatientService>();
            var contextMock = new Mock<IDoctorsAndPatientsDbContext>();

            var doctorPatients = new List<DoctorPatient>
            {
                new DoctorPatient { DoctorId = 1, PatientId = 1 },
                new DoctorPatient { DoctorId = 1, PatientId = 2 },
                new DoctorPatient { DoctorId = 2, PatientId = 3 },
            };

            doctorPatientServiceMock.Setup(dps => dps.GetAll()).Returns(doctorPatients);
            contextMock.Setup(c => c.Patients).Returns(GetTestPatientData());

            var patientService = new PatientService(contextMock.Object, doctorPatientServiceMock.Object);

            // Act
            var result = patientService.GetAllSpecialPatientsByDoctorId(doctorId);

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        private DbSet<Patient> GetTestPatientData()
        {
            var patients = new List<Patient>
            {
                new Patient { Id = 1, Name = "Patient 1" },
                new Patient { Id = 2, Name = "Patient 2" },
                new Patient { Id = 3, Name = "Patient 3" },
                new Patient { Id = 4, Name = "Patient 4" },
            };

            var patientDbSetMock = new Mock<DbSet<Patient>>();
            patientDbSetMock.As<IQueryable<Patient>>().Setup(m => m.Provider).Returns(patients.AsQueryable().Provider);
            patientDbSetMock.As<IQueryable<Patient>>().Setup(m => m.Expression).Returns(patients.AsQueryable().Expression);
            patientDbSetMock.As<IQueryable<Patient>>().Setup(m => m.ElementType).Returns(patients.AsQueryable().ElementType);
            patientDbSetMock.As<IQueryable<Patient>>().Setup(m => m.GetEnumerator()).Returns(patients.AsQueryable().GetEnumerator());

            return patientDbSetMock.Object;
        }

        [Test]
        public void CreatePatientAndDoctorPatient_TestMethodAbilityToCreatePatientAndDoctorPatient_ReturnsCorrectResult()
        {
            // Arrange
            var patient = new Patient { Id = 1, Name = "John", LastName = "Ozols" };
            var doctorId = 1;

            var contextMock = new Mock<IDoctorsAndPatientsDbContext>();
            var doctorPatientServiceMock = new Mock<IDoctorPatientService>();

            var patients = new List<Patient>();
            var doctorPatients = new List<DoctorPatient>();

            contextMock.Setup(c => c.Patients.Add(It.IsAny<Patient>())).Callback<Patient>(p => patients.Add(p));
            contextMock.Setup(c => c.SaveChanges());

            doctorPatientServiceMock.Setup(dps => dps.Create(It.IsAny<DoctorPatient>()))
                                    .Callback<DoctorPatient>(dp => doctorPatients.Add(dp));

            var patientService = new PatientService(contextMock.Object, doctorPatientServiceMock.Object);

            // Act
            var result = patientService.CreatePatientAndDoctorPatient(patient, doctorId);

            // Assert
            Assert.AreEqual(1, patients.Count);
            Assert.AreEqual(1, doctorPatients.Count);
            Assert.AreEqual(patient.Id, doctorPatients[0].PatientId);
            Assert.AreEqual(doctorId, doctorPatients[0].DoctorId);
            Assert.AreEqual(patient, result);
        } 
    }
}