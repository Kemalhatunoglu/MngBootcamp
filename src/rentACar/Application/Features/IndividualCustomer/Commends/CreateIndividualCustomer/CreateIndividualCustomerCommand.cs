using Application.Constants;
using Application.Services.OutService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.IndividualCustomer.Commends.CreateIndividualCustomer
{
    public class CreateIndividualCustomerCommand : IRequest<IDataResult<Domain.Entities.Concete.IndividualCustomer>>
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }

        public class CreateCorporateCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, IDataResult<Domain.Entities.Concete.IndividualCustomer>>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IMapper _mapper;
            private readonly IFindeksCreditService _findeksCreditService;
            private readonly IFindeksCreditRepository _findeksCreditRepository;

            public CreateCorporateCustomerCommandHandler(IMapper mapper, IIndividualCustomerRepository individualCustomerRepository, IFindeksCreditService findeksCreditService, IFindeksCreditRepository findeksCreditRepository)
            {
                _mapper = mapper;
                _individualCustomerRepository = individualCustomerRepository;
                _findeksCreditService = findeksCreditService;
                _findeksCreditRepository = findeksCreditRepository;
            }

            public async Task<IDataResult<Domain.Entities.Concete.IndividualCustomer>> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                var mapperIndividualCustomer = _mapper.Map<Domain.Entities.Concete.IndividualCustomer>(request);
                var customerToAdd = await _individualCustomerRepository.AddAsync(mapperIndividualCustomer);
                if (customerToAdd != null)
                {
                    var customerFindex = new FindeksCredit
                    {
                        CustomerId = customerToAdd.Id,
                        CustomerType = Domain.Enums.CustomerType.Corporate,
                        Score = _findeksCreditService.AssignmentScore()
                    };

                    await _findeksCreditRepository.AddAsync(customerFindex);
                    return new SuccessDataResult<Domain.Entities.Concete.IndividualCustomer>(customerToAdd, Message.SuccessCreate);
                }
                else
                    return new ErrorDataResult<Domain.Entities.Concete.IndividualCustomer>(Message.ErrorCreate);
            }
        }
    }
}
