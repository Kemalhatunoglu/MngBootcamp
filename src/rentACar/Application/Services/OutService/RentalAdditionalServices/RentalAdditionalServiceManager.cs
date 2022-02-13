using Application.Services.OutService.AdditionalServices;
using Application.Services.Repositories;
using Domain.Entities.Concete;

namespace Application.Services.OutService.RentalAdditionalServices
{
    public class RentalAdditionalServiceManager : IRentalAdditionalService
    {
        private readonly IRentalAdditionalServiceRepository _rentalAdditionalServiceRepository;
        private readonly IAdditionalService _additionalService;

        public RentalAdditionalServiceManager(IRentalAdditionalServiceRepository rentalAdditionalServiceRepository, IAdditionalService additionalService)
        {
            _rentalAdditionalServiceRepository = rentalAdditionalServiceRepository;
            _additionalService = additionalService;
        }

        public async Task AddRentalAdditionalServiceByRentalId(int rentalId, List<int> additionalServiceId)
        {
            foreach (var id in additionalServiceId)
            {
                await _rentalAdditionalServiceRepository.AddAsync(new RentalAdditionalService { RentalId = rentalId, AdditionalServiceId = id });
            }
        }

        public async Task DeleteAllRentalAdditionalServiceByRentalId(int rentalId)
        {
            var result = await _rentalAdditionalServiceRepository.GetListAsync(x => x.RentalId == rentalId);

            foreach (var item in result.Items)
            {
                await _rentalAdditionalServiceRepository.DeleteAsync(item);
                await _additionalService.UpdateAdditionalServiceCount(item.Id, false);
            }
        }

        public async Task UpdateRentalAdditionalService(int rentalId, List<int> additionalServiceId)
        {
            await DeleteAllRentalAdditionalServiceByRentalId(rentalId);
            var updateModel = new RentalAdditionalService();

            foreach (var item in additionalServiceId)
            {
                updateModel.RentalId = rentalId;
                updateModel.AdditionalServiceId = item;
                await _rentalAdditionalServiceRepository.AddAsync(updateModel);
                await _additionalService.UpdateAdditionalServiceCount(item, true);
            }
        }

        public async Task<IList<RentalAdditionalService>> GetAdditionalServiceByRentalId(int rentalId)
        {
            var result = await _rentalAdditionalServiceRepository.GetListAsync(x => x.RentalId == rentalId);
            return result.Items;
        }
    }
}
