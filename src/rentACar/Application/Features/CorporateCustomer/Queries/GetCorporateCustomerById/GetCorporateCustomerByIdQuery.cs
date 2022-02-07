using Application.Constants;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.CorporateCustomer.Queries.GetCorporateCustomerById
{
    public class GetCorporateCustomerByIdQuery : IRequest<IDataResult<Domain.Entities.Concete.CorporateCustomer>>
    {
        public int Id { get; set; }

        public class GetCorporateCustomerByIdQueryHandler : IRequestHandler<GetCorporateCustomerByIdQuery, IDataResult<Domain.Entities.Concete.CorporateCustomer>>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;

            public GetCorporateCustomerByIdQueryHandler(ICorporateCustomerRepository corporateCustomerRepository)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
            }

            public async Task<IDataResult<Domain.Entities.Concete.CorporateCustomer>> Handle(GetCorporateCustomerByIdQuery request, CancellationToken cancellationToken)
            {
                var response = await _corporateCustomerRepository.GetAsync(x => x.Id == request.Id);
                if (response == null) return new ErrorDataResult<Domain.Entities.Concete.CorporateCustomer>(Message.ErrorGet);
                return new SuccessDataResult<Domain.Entities.Concete.CorporateCustomer>(response, Message.SuccessGet);
            }
        }
    }
}
