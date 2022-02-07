using Application.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.CorporateCustomer.Commends.UpdateCorporateCustomer
{
    public class UpdateCorporateCustomerCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string TaxNo { get; set; }

        public class UpdateCorporateCustomerCommandHandler : IRequestHandler<UpdateCorporateCustomerCommand, IResult>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;

            public UpdateCorporateCustomerCommandHandler(IMapper mapper, ICorporateCustomerRepository corporateCustomerRepository)
            {
                _mapper = mapper;
                _corporateCustomerRepository = corporateCustomerRepository;
            }

            public async Task<IResult> Handle(UpdateCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                var updateModelCorporateCustomer = _mapper.Map<Domain.Entities.Concete.CorporateCustomer>(request);
                await _corporateCustomerRepository.UpdateAsync(updateModelCorporateCustomer);
                return new SuccessResult(Message.SuccessUpdate);
            }
        }
    }
}
