using Application.Constants;
using Application.Features.IndividualCustomer.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.IndividualCustomer.Queries.GetIndividualCustomerList
{
    public class GetIndividualCustomerListQuery : IRequest<IDataResult<IndividualCustomerListModel>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetIndividualCustomerListQueryHandler : IRequestHandler<GetIndividualCustomerListQuery, IDataResult<IndividualCustomerListModel>>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IMapper _mapper;

            public GetIndividualCustomerListQueryHandler(IMapper mapper, IIndividualCustomerRepository individualCustomerRepository)
            {
                _mapper = mapper;
                _individualCustomerRepository = individualCustomerRepository;
            }

            public async Task<IDataResult<IndividualCustomerListModel>> Handle(GetIndividualCustomerListQuery request, CancellationToken cancellationToken)
            {
                var individualCustomer = await _individualCustomerRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                var mappedIndividualCustomer = _mapper.Map<IndividualCustomerListModel>(individualCustomer);
                return new SuccessDataResult<IndividualCustomerListModel>(mappedIndividualCustomer, Message.SuccessGet);
            }
        }
    }
}
