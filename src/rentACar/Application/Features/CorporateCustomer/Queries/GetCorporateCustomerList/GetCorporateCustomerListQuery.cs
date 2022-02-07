using Application.Constants;
using Application.Features.CorporateCustomer.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.CorporateCustomer.Queries.GetCorporateCustomerList
{
    public class GetCorporateCustomerListQuery : IRequest<IDataResult<CorporateCustomerListModel>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetCorporateCustomerListQueryHandler : IRequestHandler<GetCorporateCustomerListQuery, IDataResult<CorporateCustomerListModel>>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;

            public GetCorporateCustomerListQueryHandler(IMapper mapper, ICorporateCustomerRepository corporateCustomerRepository)
            {
                _mapper = mapper;
                _corporateCustomerRepository = corporateCustomerRepository;
            }

            public async Task<IDataResult<CorporateCustomerListModel>> Handle(GetCorporateCustomerListQuery request, CancellationToken cancellationToken)
            {
                var corporateCustomers = await _corporateCustomerRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                var mappedCorporateCustomer = _mapper.Map<CorporateCustomerListModel>(corporateCustomers);
                return new SuccessDataResult<CorporateCustomerListModel>(mappedCorporateCustomer, Message.SuccessGet);
            }
        }
    }
}
