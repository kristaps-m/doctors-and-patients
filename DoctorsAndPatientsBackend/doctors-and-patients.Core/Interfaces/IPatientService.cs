namespace doctors_and_patients.Core.Interfaces
{
    public interface IPatientService : IEntityService<Patient>
    {
        public List<Patient> GetAllSpecialPatientsByDoctorId(int id);
    }
}
