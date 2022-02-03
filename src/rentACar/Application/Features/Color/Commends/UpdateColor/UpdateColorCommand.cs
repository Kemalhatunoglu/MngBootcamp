using Application.Constants;
using Application.Features.Color.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Color.Commends.UpdateColor
{
    public class UpdateColorCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, IResult>
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

            public async Task<IResult> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
            {
                await _colorBusinessRules.ColorNameCanNotBeDuplicatedWhenInserted(request.Name);

                var updateModelColor = _mapper.Map<Domain.Entities.Concete.Color>(request);
                await _colorRepository.UpdateAsync(updateModelColor);
                return new SuccessResult(Message.SuccessUpdate);
            }
        }
    }
}