using Application.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.CorporateCustomer.Commends.CreateCorporateCustomer
{
    public class CreateCorporateCustomerCommand : IRequest<IDataResult<Domain.Entities.Concete.CorporateCustomer>>
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string TaxNo { get; set; }

        public class CreateCorporateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, IDataResult<Domain.Entities.Concete.CorporateCustomer>>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;

            public CreateCorporateCustomerCommandHandler(IMapper mapper, ICorporateCustomerRepository corporateCustomerRepository)
            {
                _mapper = mapper;
                _corporateCustomerRepository = corporateCustomerRepository;
            }

            public async Task<IDataResult<Domain.Entities.Concete.CorporateCustomer>> Handle(CreateCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                var mapperCorporateCustomer = _mapper.Map<Domain.Entities.Concete.CorporateCustomer>(request);
                var customerToAdd = await _corporateCustomerRepository.AddAsync(mapperCorporateCustomer);
                return new SuccessDataResult<Domain.Entities.Concete.CorporateCustomer>(customerToAdd, Message.SuccessCreate);
            }
        }
    }
}
