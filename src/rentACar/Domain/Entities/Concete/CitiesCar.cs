using Core.Persistence.Repositories;

namespace Domain.Entities.Concete
{
    public class CitiesCar : Entity
    {
        public int CityId { get; set; }
        public int CarId { get; set; }

        public CitiesCar()
        {

        }

        public CitiesCar(int id, int cityId, int carId) : this()
        {
            Id = id;
            CityId = cityId;
            CarId = carId;
        }
    }
}
