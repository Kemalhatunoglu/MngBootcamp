using Application.Features.Color.Dtos;
using Application.Features.Color.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Color.Commends.UpdateColor
{
    public class UpdateColorCommand : IRequest<ColorUpdateDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, ColorUpdateDto>
        {
            private readonly IColorRepository _colorRepository;
            private readonly IMapper _mapper;
            private readonly ColorBusinessRules _colorBusinessRules;

            public UpdateColorCommandHandler(ColorBusinessRules colorBusinessRules, IMapper mapper, IColorRepository colorRepository)
            {
                _colorBusinessRules = colorBusinessRules;
                _mapper = mapper;
                _colorRepository = colorRepository;
            }

            public async Task<ColorUpdateDto> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
            {
                var existColor = await _colorRepository.GetAsync(x => x.Id == request.Id);
                if (existColor == null) throw new Exception("Color reference error.");
                await _colorBusinessRules.ColorNameCanNotBeDuplicatedWhenInserted(request.Name);

                existColor.Name = request.Name;
                await _colorRepository.UpdateAsync(existColor);
                var mappedColor = _mapper.Map<ColorUpdateDto>(existColor);
                return mappedColor;
            }
        }
    }
}
