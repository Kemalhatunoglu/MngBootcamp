using Core.Persistence.Repositories;
using Domain.Entities.Concete;

namespace Application.Services.Repositories //Bu katman dış katmanlardan hizmet almayı düşündüğümüz kontratların temelidir.
{
    public interface IBrandRepository : IAsyncRepository<Brand>
    {
    }
}
