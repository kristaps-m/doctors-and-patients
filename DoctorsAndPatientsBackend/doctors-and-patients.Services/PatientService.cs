using doctors_and_patients.Core;
using doctors_and_patients.Data;
using doctors_and_patients.Services.Interfaces;

namespace doctors_and_patients.Services
{
    public class PatientService : EntityService<Patient>, IPatientService
    {
        public PatientService(IDoctorsAndPatientsDbContext context) : base(context)
        {

        }
    }
}
