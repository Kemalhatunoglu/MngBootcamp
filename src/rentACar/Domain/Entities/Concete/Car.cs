﻿using Core.Persistence.Repositories;

namespace Domain.Entities.Concete
{
    public class Car : Entity
    {
        public Car()
        {

        }

        public Car(int id, int modelId, int colorId, string plate, short modelYear) : this()
        {
            Id = id;
            ModelId = modelId;
            ColorId = colorId;
            Plate = plate;
            ModelYear = modelYear;
        }

        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }

        public virtual Color Color { get; set; }
        public virtual Model Model { get; set; }
    }
}
