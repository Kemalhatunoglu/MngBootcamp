namespace Domain.Entities.Concete
{
    public class IndividualCustomer : Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }

        public IndividualCustomer()
        {

        }

        public IndividualCustomer(int id, string email, string phone, float findeksRate, string firstName, string lastName, string nationalIdentity) : base(id, email, phone, findeksRate)
        {
            FirstName = firstName;
            LastName = lastName;
            NationalIdentity = nationalIdentity;
        }
    }
}
