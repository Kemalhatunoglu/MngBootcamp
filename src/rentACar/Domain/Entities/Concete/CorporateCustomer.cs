namespace Domain.Entities.Concete
{
    public class CorporateCustomer : Customer
    {
        public string CompanyName { get; set; }
        public string TaxNo { get; set; }

        public CorporateCustomer()
        {

        }

        public CorporateCustomer(int id, string email, string phone, string companyName, string taxNo) : base(id, email, phone)
        {
            CompanyName = companyName;
            TaxNo = taxNo;
        }
    }
}
