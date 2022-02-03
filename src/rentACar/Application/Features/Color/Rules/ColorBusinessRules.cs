using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Color.Rules
{
    public class ColorBusinessRules
    {
        private readonly IColorRepository _colorRepository;

        public ColorBusinessRules(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task ColorNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _colorRepository.GetListAsync(x => x.Name == name);
            if (result.Items.Any())
                throw new BusinessException("Color name exists");
        }
    }
}
