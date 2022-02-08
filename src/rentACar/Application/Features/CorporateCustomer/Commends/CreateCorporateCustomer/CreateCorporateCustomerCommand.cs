using Application.Constants;
using Application.Services.OutService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.CorporateCustomer.Commends.CreateCorporateCustomer
{
    public class CreateCorporateCustomerCommand : IRequest<IDataResult<Domain.Entities.Concete.CorporateCustomer>>
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string TaxNo { get; set; }
        public float? FindeksRate { get; set; } = 100;

        public class CreateCorporateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, IDataResult<Domain.Entities.Concete.CorporateCustomer>>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;
            private readonly IFindeksCreditService _findeksCreditService;
            private readonly IFindeksCreditRepository _findeksCreditRepository;

            public CreateCorporateCustomerCommandHandler(IMapper mapper, ICorporateCustomerRepository corporateCustomerRepository, IFindeksCreditService findeksCreditService, IFindeksCreditRepository findeksCreditRepository)
            {
                _mapper = mapper;
                _corporateCustomerRepository = corporateCustomerRepository;
                _findeksCreditService = findeksCreditService;
                _findeksCreditRepository = findeksCreditRepository;
            }

            public async Task<IDataResult<Domain.Entities.Concete.CorporateCustomer>> Handle(CreateCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                var mapperCorporateCustomer = _mapper.Map<Domain.Entities.Concete.CorporateCustomer>(request);
                var customerToAdd = await _corporateCustomerRepository.AddAsync(mapperCorporateCustomer);
                if (customerToAdd != null)
                {
                    var customerFindex = new FindeksCredit
                    {
                        CustomerId = customerToAdd.Id,
                        CustomerType = Domain.Enums.CustomerType.Corporate,
                        Score = _findeksCreditService.AssignmentScore()
                    };

                    await _findeksCreditRepository.AddAsync(customerFindex);
                    return new SuccessDataResult<Domain.Entities.Concete.CorporateCustomer>(customerToAdd, Message.SuccessCreate);
                }
                else
                    return new ErrorDataResult<Domain.Entities.Concete.CorporateCustomer>(Message.ErrorCreate);
            }
        }
    }
}
