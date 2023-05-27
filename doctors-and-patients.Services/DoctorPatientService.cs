using doctors_and_patients.Core;
using doctors_and_patients.Data;
using doctors_and_patients.Services.Interfaces;

namespace doctors_and_patients.Services
{
    public class DoctorPatientService : EntityService<DoctorPatient>, IDoctorPatientService
    {
        public DoctorPatientService(IDoctorsAndPatientsDbContext context) : base(context)
        {

        }
    }
}
