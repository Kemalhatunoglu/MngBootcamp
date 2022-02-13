using Domain.Dtos;

namespace Application.Services.OutService.Cars
{
    public interface ICarService
    {
        CarDetailDto GetCarDetail(int id);
    }
}
