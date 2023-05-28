namespace doctors_and_patients.Core.Interfaces
{
    public interface IPatientService : IEntityService<Patient>
    {
        public List<Patient> GetAllSpecialPatientsByDoctorId(int id);
        public Patient UpdateOnePatient(Patient patient, int id);
        public void DeleteOnePatient(int id);
        public Patient CreatePatientAndDoctorPatient(Patient patient, int doctorId);
    }
}
