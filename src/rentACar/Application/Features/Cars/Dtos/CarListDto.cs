﻿using Domain.Enums;

namespace Application.Features.Cars.Dtos
{
    public class CarListDto
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public int CityId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }
        public CarState CarState { get; set; }
    }
}
