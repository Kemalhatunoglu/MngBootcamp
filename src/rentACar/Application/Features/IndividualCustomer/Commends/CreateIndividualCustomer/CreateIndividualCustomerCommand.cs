using Application.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
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

            public CreateCorporateCustomerCommandHandler(IMapper mapper, IIndividualCustomerRepository individualCustomerRepository)
            {
                _mapper = mapper;
                _individualCustomerRepository = individualCustomerRepository;
            }

            public async Task<IDataResult<Domain.Entities.Concete.IndividualCustomer>> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                var mapperIndividualCustomer = _mapper.Map<Domain.Entities.Concete.IndividualCustomer>(request);
                var customerToAdd = await _individualCustomerRepository.AddAsync(mapperIndividualCustomer);
                return new SuccessDataResult<Domain.Entities.Concete.IndividualCustomer>(customerToAdd, Message.SuccessCreate);
            }
        }
    }
}
