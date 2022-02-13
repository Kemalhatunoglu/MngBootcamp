using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities.Concete
{
    public class Invoice : Entity
    {
        public string InvoiceNo { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public float RentalDayCount { get; set; }
        public float TotalFee { get; set; }
        public int CustomerId { get; set; }
        public CustomerType CustomerType { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

        public Invoice()
        {
            Cars = new HashSet<Car>();
        }

        public Invoice(int id, string invoiceNo, DateTime creationDate, DateTime rentalStartDate, DateTime rentalEndDate, float rentalDayCount, float totalFee, int customerId, CustomerType customerType) : this()
        {
            Id = id;
            InvoiceNo = invoiceNo;
            CreationDate = creationDate;
            RentalStartDate = rentalStartDate;
            RentalEndDate = rentalEndDate;
            RentalDayCount = rentalDayCount;
            TotalFee = totalFee;
            CustomerId = customerId;
            CustomerType = customerType;
        }
    }
}
