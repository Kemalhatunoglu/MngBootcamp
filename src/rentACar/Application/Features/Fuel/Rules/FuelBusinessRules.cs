using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Fuel.Rules
{
    public class FuelBusinessRules
    {
        private readonly IFuelRepository _fuelRepository;

        public FuelBusinessRules(IFuelRepository fuelRepository)
        {
            _fuelRepository = fuelRepository;
        }

        public async Task FuelNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _fuelRepository.GetListAsync(x => x.Name == name);
            if (result.Items.Any())
                throw new BusinessException("Fuel name exists");
        }
    }
}
