using Application.Constants;
using Application.Features.AdditionalServices.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Dtos;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.AdditionalServices.Queries
{
    public class GetListAdditionalServiceQuery : IRequest<IDataResult<List<AdditionalServiceDto>>>
    {
        public class GetListAdditionalServiceQueryHandler : IRequestHandler<GetListAdditionalServiceQuery, IDataResult<List<AdditionalServiceDto>>>
        {
            private readonly IAdditionalServiceRepository _additionalServiceRepository;
            private readonly IMapper _mapper;

            public GetListAdditionalServiceQueryHandler(IAdditionalServiceRepository additionalServiceRepository, IMapper mapper)
            {
                _additionalServiceRepository = additionalServiceRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<List<AdditionalServiceDto>>> Handle(GetListAdditionalServiceQuery request, CancellationToken cancellationToken)
            {
                List<AdditionalServiceDto> additionalServiceDto = await _additionalServiceRepository.GetAll();
                return new SuccessDataResult<List<AdditionalServiceDto>>(additionalServiceDto, Message.SuccessGet);
            }
        }
    }
}
