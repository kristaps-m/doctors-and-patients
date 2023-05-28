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

        public DoctorPatient UpdateOneDoctorPatient(DoctorPatient doctorPatient, int id)
        {
            var doctorPatientToUpdate = _context.DoctorPatients.SingleOrDefault(p => p.Id == id);
            if (doctorPatientToUpdate != null)
            {
                doctorPatientToUpdate.DoctorId = doctorPatient.DoctorId;
                doctorPatientToUpdate.PatientId = doctorPatient.PatientId;
                _context.Entry(doctorPatientToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return doctorPatientToUpdate;
        }

        public void DeleteOneDoctorPatient(int id)
        {
            var doctorPatientToDelete = _context.DoctorPatients.SingleOrDefault(p => p.Id == id);
            _context.DoctorPatients.Remove(doctorPatientToDelete);
            _context.SaveChanges();
        }
    }
}
