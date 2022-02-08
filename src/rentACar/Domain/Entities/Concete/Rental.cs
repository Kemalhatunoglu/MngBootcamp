using Core.Persistence.Repositories;

namespace Domain.Entities.Concete
{
    public class Rental : Entity
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int RentedCityId { get; set; }
        public int? DeliveryCityId { get; set; }

        public virtual Car Car { get; set; }

        public Rental()
        {
        }

        public Rental(int id, int carId, DateTime startDate, DateTime endDate, DateTime? returnDate)
        {
            Id = id;
            CarId = carId;
            StartDate = startDate;
            EndDate = endDate;
            ReturnDate = returnDate;
        }
    }
}
