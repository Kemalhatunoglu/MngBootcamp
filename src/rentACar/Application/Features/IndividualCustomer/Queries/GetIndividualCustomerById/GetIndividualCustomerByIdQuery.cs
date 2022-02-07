using Application.Constants;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.IndividualCustomer.Queries.GetIndividualCustomerById
{
    public class GetIndividualCustomerByIdQuery : IRequest<IDataResult<Domain.Entities.Concete.IndividualCustomer>>
    {
        public int Id { get; set; }

        public class GetIndividualCustomerByIdQueryHandler : IRequestHandler<GetIndividualCustomerByIdQuery, IDataResult<Domain.Entities.Concete.IndividualCustomer>>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;

            public GetIndividualCustomerByIdQueryHandler(IIndividualCustomerRepository individualCustomerRepository)
            {
                _individualCustomerRepository = individualCustomerRepository;
            }

            public async Task<IDataResult<Domain.Entities.Concete.IndividualCustomer>> Handle(GetIndividualCustomerByIdQuery request, CancellationToken cancellationToken)
            {
                var response = await _individualCustomerRepository.GetAsync(x => x.Id == request.Id);
                if (response == null) return new ErrorDataResult<Domain.Entities.Concete.IndividualCustomer>(Message.ErrorGet);
                return new SuccessDataResult<Domain.Entities.Concete.IndividualCustomer>(response, Message.SuccessGet);
            }
        }
    }
}
