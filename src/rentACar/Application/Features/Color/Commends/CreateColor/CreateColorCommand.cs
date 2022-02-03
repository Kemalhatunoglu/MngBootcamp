using Application.Features.Color.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Color.Commends.CreateColor
{
    public class CreateColorCommand : IRequest<Domain.Entities.Concete.Color>
    {
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateColorCommand, Domain.Entities.Concete.Color>
        {
            private readonly IColorRepository _colorRepository;
            private readonly IMapper _mapper;
            private readonly ColorBusinessRules _colorBusinessRules;

            public CreateBrandCommandHandler(IColorRepository colorRepository, IMapper mapper, ColorBusinessRules colorBusinessRules)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
                _colorBusinessRules = colorBusinessRules;
            }

            public async Task<Domain.Entities.Concete.Color> Handle(CreateColorCommand request, CancellationToken cancellationToken)
            {
                await _colorBusinessRules.ColorNameCanNotBeDuplicatedWhenInserted(request.Name);
                var mappedColor = _mapper.Map<Domain.Entities.Concete.Color>(request);
                var createdColor = await _colorRepository.AddAsync(mappedColor);
                return createdColor;
            }
        }
    }
}
