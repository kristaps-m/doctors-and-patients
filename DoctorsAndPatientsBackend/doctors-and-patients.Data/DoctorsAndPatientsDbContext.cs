using doctors_and_patients.Core;
using Microsoft.EntityFrameworkCore;

namespace doctors_and_patients.Data
{
    public class DoctorsAndPatientsDbContext : DbContext, IDoctorsAndPatientsDbContext
    {
        public DoctorsAndPatientsDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<DoctorPatient> DoctorPatients { get; set; }
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
