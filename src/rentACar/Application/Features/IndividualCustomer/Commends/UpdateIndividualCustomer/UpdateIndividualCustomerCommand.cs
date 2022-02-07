using Application.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.IndividualCustomer.Commends.UpdateIndividualCustomer
{
    public class UpdateIndividualCustomerCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }

        public class UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand, IResult>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IMapper _mapper;

            public UpdateIndividualCustomerCommandHandler(IMapper mapper, IIndividualCustomerRepository individualCustomerRepository)
            {
                _mapper = mapper;
                _individualCustomerRepository = individualCustomerRepository;
            }

            public async Task<IResult> Handle(UpdateIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                var updateModelIndividualCustomer = _mapper.Map<Domain.Entities.Concete.IndividualCustomer>(request);
                await _individualCustomerRepository.UpdateAsync(updateModelIndividualCustomer);
                return new SuccessResult(Message.SuccessUpdate);
            }
        }
    }
}
