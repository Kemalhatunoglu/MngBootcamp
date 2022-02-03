using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Transmissions.Rules
{
    public class TransmissionBusinessRules
    {
        private readonly ITransmissionRepository _transmissionRepository;

        public TransmissionBusinessRules(ITransmissionRepository transmissionRepository)
        {
            _transmissionRepository = transmissionRepository;
        }

        public async Task TransmissionNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _transmissionRepository.GetListAsync(x => x.Name == name);
            if (result.Items.Any())
                throw new BusinessException("Transmission name exists");
        }
    }
}
