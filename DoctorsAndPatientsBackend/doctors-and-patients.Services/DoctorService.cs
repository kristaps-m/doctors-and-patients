using doctors_and_patients.Core;
using doctors_and_patients.Data;
using doctors_and_patients.Core.Interfaces;

namespace doctors_and_patients.Services
{
    public class DoctorService : EntityService<Doctor>, IDoctorService
    {
        public DoctorService(IDoctorsAndPatientsDbContext context) : base(context) { }
    }
}
