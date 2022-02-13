using Application.Constants;
using Application.Features.AdditionalServices.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.AdditionalServices.Queries
{
    public class GetListAdditionalServiceQuery : IRequest<IDataResult<AdditionalServiceListModel>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListAdditionalServiceQueryHandler : IRequestHandler<GetListAdditionalServiceQuery, IDataResult<AdditionalServiceListModel>>
        {
            private readonly IAdditionalServiceRepository _additionalServiceRepository;
            private readonly IMapper _mapper;

            public GetListAdditionalServiceQueryHandler(IAdditionalServiceRepository additionalServiceRepository, IMapper mapper)
            {
                _additionalServiceRepository = additionalServiceRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<AdditionalServiceListModel>> Handle(GetListAdditionalServiceQuery request, CancellationToken cancellationToken)
            {
                IPaginate<AdditionalService> additionalServices = await _additionalServiceRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                var mappedAdditionalServiceListModel = _mapper.Map<AdditionalServiceListModel>(additionalServices);
                return new SuccessDataResult<AdditionalServiceListModel>(mappedAdditionalServiceListModel, Message.SuccessGet);
            }
        }
    }
}
