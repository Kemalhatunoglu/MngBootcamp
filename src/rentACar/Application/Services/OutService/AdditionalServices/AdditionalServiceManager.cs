using Application.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities.Concete;

namespace Application.Services.OutService.AdditionalServices
{
    public class AdditionalServiceManager : IAdditionalService
    {
        private readonly IAdditionalServiceRepository _additionalServiceRepository;
        private readonly IRentalAdditionalServiceRepository _rentalAdditionalServiceRepository;


        public AdditionalServiceManager(IAdditionalServiceRepository additionalServiceRepository, IRentalAdditionalServiceRepository rentalAdditionalServiceRepository)
        {
            _additionalServiceRepository = additionalServiceRepository;
            _rentalAdditionalServiceRepository = rentalAdditionalServiceRepository;
        }

        public async Task<List<float>> GetAdditionalServicePriceList(List<int> additionalIdList, int rentalId)
        {
            var result = await CalcAdditionalServicePrice(additionalIdList);
            await AddRentalAdditionalService(rentalId, additionalIdList);
            return result;
        }

        public async Task AddRentalAdditionalService(int rentalId, List<int> additionalIdList)
        {
            var model = new RentalAdditionalService();
            foreach (var id in additionalIdList)
            {
                model.RentalId = rentalId;
                model.AdditionalServiceId = id;
                await _rentalAdditionalServiceRepository.AddAsync(model);
            }
        }

        public async Task UpdateAdditionalServiceCount(int additionalId, bool isSelect)
        {
            var selectedAdditionalService = await _additionalServiceRepository.GetAsync(x => x.Id == additionalId);
            if (selectedAdditionalService.Count < 1) throw new BusinessException(Message.AdditionalServiceNotEnough);

            if (isSelect)
                selectedAdditionalService.Count--;
            else
                selectedAdditionalService.Count++;
        }

        public async Task<List<float>> CalcAdditionalServicePrice(List<int> additionalIdList)
        {
            List<float> additionalPriceList = new List<float>();

            foreach (var id in additionalIdList)
            {
                await UpdateAdditionalServiceCount(id, true);

                var result = await _additionalServiceRepository.GetAsync(x => x.Id == id);
                additionalPriceList.Add(result.DailyPrice);
            }
            return additionalPriceList;
        }
    }
}
