using Core.Persistence.Repositories;
using Domain.Dtos;
using Domain.Entities.Concete;

namespace Application.Services.Repositories
{
    public interface IAdditionalServiceRepository : IAsyncRepository<AdditionalService>
    {
        Task<List<AdditionalServiceDto>> GetAll();
    }
}
