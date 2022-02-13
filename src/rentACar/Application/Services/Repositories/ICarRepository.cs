using Core.Persistence.Repositories;
using Domain.Dtos;
using Domain.Entities.Concete;

namespace Application.Services.Repositories
{
    public interface ICarRepository : IAsyncRepository<Car>
    {
        CarDetailDto GetCarDetailToRental(int id);
    }
}
