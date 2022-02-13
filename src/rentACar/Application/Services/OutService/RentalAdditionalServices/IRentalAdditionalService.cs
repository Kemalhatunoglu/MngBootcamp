using Domain.Entities.Concete;

namespace Application.Services.OutService.RentalAdditionalServices
{
    public interface IRentalAdditionalService
    {
        Task<IList<RentalAdditionalService>> GetAdditionalServiceByRentalId(int rentalId);
        Task AddRentalAdditionalServiceByRentalId(int rentalId, List<int> additionalServiceId);
        Task DeleteAllRentalAdditionalServiceByRentalId(int rentalId);
        Task UpdateRentalAdditionalService(int rentalId, List<int> additionalServiceId);
    }
}
