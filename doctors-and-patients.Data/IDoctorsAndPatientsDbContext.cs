using doctors_and_patients.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace doctors_and_patients.Data
{
    public interface IDoctorsAndPatientsDbContext
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
        DbSet<DoctorPatient> DoctorPatients { get; set; }
        DbSet<Doctor> Doctors { get; set; }
        DbSet<Patient> Patients { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}