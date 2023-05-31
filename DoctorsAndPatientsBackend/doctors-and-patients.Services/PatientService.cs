using doctors_and_patients.Core;
using doctors_and_patients.Data;
using doctors_and_patients.Core.Interfaces;

namespace doctors_and_patients.Services
{
    public class PatientService : EntityService<Patient>, IPatientService
    {
        private readonly IDoctorPatientService _doctorPatientService;

        public PatientService(IDoctorsAndPatientsDbContext context, IDoctorPatientService doctorPatientService) : base(context)
        {
            _doctorPatientService = doctorPatientService;
        }

        public List<Patient> GetAllSpecialPatientsByDoctorId(int id)
        {
            var doctorPatientIds = new List<int>() { };

            foreach (var doctorPatient in _doctorPatientService.GetAll<DoctorPatient>())
            {
                if (doctorPatient.DoctorId == id)
                {
                    doctorPatientIds.Add(doctorPatient.PatientId);
                }
            }

            var patients = _context.Patients.Where(x => doctorPatientIds.Contains(x.Id));

            return patients.ToList();
        }

        public Patient UpdateOnePatient(Patient patient, int id)
        {
            var patientToUpdate = _context.Patients.SingleOrDefault(p => p.Id == id);
            if (patientToUpdate != null)
            {
                patientToUpdate.Name = patient.Name;
                patientToUpdate.LastName = patient.LastName;
                patientToUpdate.DateOfBirth = patient.DateOfBirth;
                patientToUpdate.City = patient.City;
                _context.Entry(patientToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return patientToUpdate;
        }

        public void DeleteOnePatient(int id)
        {
            var patientToDelete = _context.Patients.SingleOrDefault(p => p.Id == id);
            _context.Patients.Remove(patientToDelete);
            _context.SaveChanges();
        }

        public Patient CreatePatientAndDoctorPatient(Patient patient, int doctorId)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            var doctorPatient = new DoctorPatient();
            doctorPatient.PatientId = patient.Id;
            doctorPatient.DoctorId = doctorId;
            _doctorPatientService.Create(doctorPatient);

            return patient;
        }
    }
}
