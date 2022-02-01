using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.Models.Commends.UpdateModel
{
    public class UpdateModelCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int FuelId { get; set; }
        public int TransmissionId { get; set; }
        public string Name { get; set; }
        public double DailyPrice { get; set; }
        public string ImageUrl { get; set; }

        public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, IResult>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;
            private readonly ModelBusinessRules _modelBusinessRules;

            public UpdateModelCommandHandler(IMapper mapper, IModelRepository modelRepository, ModelBusinessRules modelBusinessRules)
            {
                _mapper = mapper;
                _modelRepository = modelRepository;
                _modelBusinessRules = modelBusinessRules;
            }

            public async Task<IResult> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
            {
                var isExistModel = await _modelRepository.GetAsync(x => x.Id == request.Id);
                await _modelBusinessRules.ModelNameCanNotBeDuplicatedWhenInserted(isExistModel.Name);
                var mapperModel = _mapper.Map<Model>(isExistModel);
                await _modelRepository.UpdateAsync(mapperModel);
                return new SuccessResult("The update has been performed.");
            }
        }
    }
}
