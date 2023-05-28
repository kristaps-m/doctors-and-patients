namespace doctors_and_patients.Core.Interfaces
{
    public interface IDoctorService : IEntityService<Doctor>
    {
        public Doctor UpdateOneDoctor(Doctor doctor, int id);
        public void DeleteOneDoctor(int id);
    }
}
