using Domain.Enums;

namespace Application.Features.Invoices.Dtos
{
    public class InvoiceListDto
    {
        public int Id { get; set; }
        public int InvoiceNo { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public float RentalDayCount { get; set; }
        public double TotalFee { get; set; }
        public int CustomerId { get; set; }
        public CustomerType CustomerType { get; set; }
    }
}
