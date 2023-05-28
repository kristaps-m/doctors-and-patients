using doctors_and_patients.Core;
using doctors_and_patients.Data;
using doctors_and_patients.Core.Interfaces;

namespace doctors_and_patients.Services
{
    public class DoctorService : EntityService<Doctor>, IDoctorService
    {
        public DoctorService(IDoctorsAndPatientsDbContext context) : base(context) { }

        public Doctor UpdateOneDoctor(Doctor doctor, int id)
        {
            var doctorToUpdate = _context.Doctors.SingleOrDefault(p => p.Id == id);
            if (doctorToUpdate != null)
            {
                doctorToUpdate.Name = doctor.Name;
                doctorToUpdate.LastName = doctor.LastName;
                _context.Entry(doctorToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return doctorToUpdate;
        }

        public void DeleteOneDoctor(int id)
        {
            var patientToDelete = _context.Doctors.SingleOrDefault(p => p.Id == id);
            _context.Doctors.Remove(patientToDelete);
            _context.SaveChanges();
        }
    }
}
