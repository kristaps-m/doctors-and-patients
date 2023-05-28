using doctors_and_patients.Core;
using doctors_and_patients.Core.Interfaces;
using doctors_and_patients.Data;

namespace doctors_and_patients.Services
{
    public class DoctorPatientService : EntityService<DoctorPatient>, IDoctorPatientService
    {
        public DoctorPatientService(IDoctorsAndPatientsDbContext context) : base(context)
        {

        }
    }
}
