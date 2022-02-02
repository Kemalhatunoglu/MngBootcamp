using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities.Concete
{
    public class Car : Entity
    {
        public Car()
        {

        }

        public Car(int id, int modelId, int colorId, string plate, short modelYear, CarState carState) : this()
        {
            Id = id;
            ModelId = modelId;
            ColorId = colorId;
            Plate = plate;
            ModelYear = modelYear;
            CarState = carState;
        }

        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }
        public CarState CarState { get; set; }

        public virtual Color Color { get; set; }
        public virtual Model Model { get; set; }
    }
}
