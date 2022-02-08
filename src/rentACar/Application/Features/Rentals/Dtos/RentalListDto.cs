using Domain.Enums;

namespace Application.Features.Rentals.Dtos
{
    public class RentalListDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public CarState CarState { get; set; }
        public DateTime? MaintainStartDate { get; set; }
        public DateTime? MaintainEndDate { get; set; }
        public int? DeliveryCityId { get; set; }
    }
}
