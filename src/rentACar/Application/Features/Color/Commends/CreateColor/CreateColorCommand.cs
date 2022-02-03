using Application.Constants;
using Application.Features.Color.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Color.Commends.CreateColor
{
    public class CreateColorCommand : IRequest<IDataResult<Domain.Entities.Concete.Color>>
    {
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateColorCommand, IDataResult<Domain.Entities.Concete.Color>>
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

            public async Task<IDataResult<Domain.Entities.Concete.Color>> Handle(CreateColorCommand request, CancellationToken cancellationToken)
            {
                await _colorBusinessRules.ColorNameCanNotBeDuplicatedWhenInserted(request.Name);
                var mappedColor = _mapper.Map<Domain.Entities.Concete.Color>(request);
                var colorToAdd = await _colorRepository.AddAsync(mappedColor);
                return new SuccessDataResult<Domain.Entities.Concete.Color>(colorToAdd, Message.SuccessCreate);
            }
        }
    }
}
