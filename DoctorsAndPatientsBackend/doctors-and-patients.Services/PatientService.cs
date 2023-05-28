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

            foreach (var doctorPatient in _doctorPatientService.GetAll())
            {
                if (doctorPatient.DoctorId == id)
                {
                    doctorPatientIds.Add(doctorPatient.PatientId);
                }
            }

            var patients = _context.Patients.Where(x => doctorPatientIds.Contains(x.Id));

            return patients.ToList();
        }
    }
}
