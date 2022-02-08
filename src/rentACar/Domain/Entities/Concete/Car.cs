using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities.Concete
{
    public class Car : Entity
    {
        public Car()
        {

        }

        public Car(int id, int modelId, int colorId, int cityId, string plate, double startingKm, double finishKm, short modelYear, CarState carState, DateTime maintainStartDate, DateTime maintainEndDate) : this()
        {
            Id = id;
            ModelId = modelId;
            ColorId = colorId;
            CityId = cityId;
            Plate = plate;
            ModelYear = modelYear;
            CarState = carState;
            MaintainStartDate = maintainStartDate;
            MaintainEndDate = maintainEndDate;
            StartingKm = startingKm;
            FinishKm = finishKm;
        }

        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public int CityId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }
        public CarState CarState { get; set; }
        public DateTime? MaintainStartDate { get; set; }
        public DateTime? MaintainEndDate { get; set; }
        public double StartingKm { get; set; }
        public double? FinishKm { get; set; }

        public virtual Color Color { get; set; }
        public virtual Model Model { get; set; }
        public virtual City City { get; set; }

    }
}
