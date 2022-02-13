using Core.Persistence.Repositories;

namespace Domain.Entities.Concete
{
    public class RentalAdditionalService : Entity
    {
        public RentalAdditionalService()
        {

        }

        public RentalAdditionalService(int id, int rentalId, int additionalServiceId) : base(id)
        {
            Id = id;
            RentalId = rentalId;
            AdditionalServiceId = additionalServiceId;
        }

        public int RentalId { get; set; }
        public int AdditionalServiceId { get; set; }

        public virtual Rental Rental { get; set; }
        public virtual AdditionalService AdditionalService { get; set; }
    }
}
