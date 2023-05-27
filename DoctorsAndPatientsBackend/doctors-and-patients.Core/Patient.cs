namespace doctors_and_patients.Core
{
    public class Patient : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
    }
}
