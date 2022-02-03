using Application.Constants;
using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Models.Queries
{
    public class GetModelListQuery : IRequest<IDataResult<ModelListModel>>
    {
        public PageRequest PageRequest { get; set; }

        class GetModelListQueryHandler : IRequestHandler<GetModelListQuery, IDataResult<ModelListModel>>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public GetModelListQueryHandler(IMapper mapper, IModelRepository modelRepository)
            {
                _mapper = mapper;
                _modelRepository = modelRepository;
            }

            public async Task<IDataResult<ModelListModel>> Handle(GetModelListQuery request, CancellationToken cancellationToken)
            {
                var models = await _modelRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );
                var mappedModel = _mapper.Map<ModelListModel>(models);

                return new SuccessDataResult<ModelListModel>(mappedModel, Message.SuccessGet);
            }
        }
    }
}
