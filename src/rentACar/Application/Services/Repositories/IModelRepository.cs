using Core.Persistence.Repositories;
using Domain.Dtos;
using Domain.Entities.Concete;

namespace Application.Services.Repositories
{
    public interface IModelRepository : IAsyncRepository<Model>
    {
        List<ModelDetailDto> GetAllModelDetail();
    }
}
