using Application.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities.Concete;

namespace Application.Features.AdditionalServices.Rules
{
    public class AdditionalServiceBusinessRules
    {
        private readonly IAdditionalServiceRepository _additionalServiceRepository;

        public AdditionalServiceBusinessRules(IAdditionalServiceRepository additionalServiceRepository)
        {
            _additionalServiceRepository = additionalServiceRepository;
        }

        public async Task AdditionalServiceIsExists(int id)
        {
            AdditionalService? result = await _additionalServiceRepository.GetAsync(b => b.Id == id);
            if (result == null) throw new BusinessException(Message.NotFound);
        }

        public async Task AdditionalServiceNameCanNotBeDuplicated(string name)
        {
            IPaginate<AdditionalService> result = await _additionalServiceRepository.GetListAsync(a => a.Name == name);
            if (result.Items.Any()) throw new BusinessException(Message.ExistingData);
        }
    }
}
