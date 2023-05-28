namespace doctors_and_patients.Core.Interfaces
{
    public interface IDoctorPatientService : IEntityService<DoctorPatient>
    {
        public DoctorPatient UpdateOneDoctorPatient(DoctorPatient doctorPatient, int id);
        public void DeleteOneDoctorPatient(int id);
    }
}
