using Core.Persistence.Repositories;
using Domain.Entities.Concete;

namespace Application.Services.Repositories
{
    public interface ICityRepository : IAsyncRepository<City>
    {
    }
}
