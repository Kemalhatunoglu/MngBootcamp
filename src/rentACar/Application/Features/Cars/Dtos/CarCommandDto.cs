using Domain.Enums;

namespace Application.Features.Cars.Dtos
{
    public class CarCommandDto
    {
        public int Id { get; set; }
        public string ModelId { get; set; }
        public string ColorId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }
        public CarState CarState { get; set; }
    }
}
