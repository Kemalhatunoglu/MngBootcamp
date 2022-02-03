using Application.Constants;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.Models.Commends.CreateModel
{
    public class CreateModelCommand : IRequest<IDataResult<Model>>
    {
        public int BrandId { get; set; }
        public int FuelId { get; set; }
        public int TransmissionId { get; set; }
        public string Name { get; set; }
        public double DailyPrice { get; set; }
        public string ImageUrl { get; set; }

        public class CreateModelResponse : IRequestHandler<CreateModelCommand, IDataResult<Model>>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;
            private readonly ModelBusinessRules _modelBusinessRules;

            public CreateModelResponse(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
                _modelBusinessRules = modelBusinessRules;
            }

            public async Task<IDataResult<Model>> Handle(CreateModelCommand request, CancellationToken cancellationToken)
            {
                await _modelBusinessRules.ModelNameCanNotBeDuplicatedWhenInserted(request.Name);
                _modelBusinessRules.ModelDailyPriceCanNotBeLessThanZero(request.DailyPrice);

                var mapperModel = _mapper.Map<Model>(request);
                var modelToAdd = await _modelRepository.AddAsync(mapperModel);
                return new SuccessDataResult<Model>(modelToAdd, Message.SuccessCreate);
            }
        }
    }
}
