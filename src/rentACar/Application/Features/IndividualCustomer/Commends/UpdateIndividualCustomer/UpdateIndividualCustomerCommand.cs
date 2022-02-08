using Application.Constants;
using Application.Services.OutService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
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
        public float? FindeksRate { get; set; }


        public class UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand, IResult>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IMapper _mapper;
            private readonly IFindeksCreditService _findeksCreditService;
            private readonly IFindeksCreditRepository _findeksCreditRepository;

            public UpdateIndividualCustomerCommandHandler(IMapper mapper, IIndividualCustomerRepository individualCustomerRepository, IFindeksCreditService findeksCreditService, IFindeksCreditRepository findeksCreditRepository)
            {
                _mapper = mapper;
                _individualCustomerRepository = individualCustomerRepository;
                _findeksCreditService = findeksCreditService;
                _findeksCreditRepository = findeksCreditRepository;
            }

            public async Task<IResult> Handle(UpdateIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                var updateModelIndividualCustomer = _mapper.Map<Domain.Entities.Concete.IndividualCustomer>(request);
                await _individualCustomerRepository.UpdateAsync(updateModelIndividualCustomer);

                if (request.FindeksRate != null)
                {
                    var findexByCustomerId = await _findeksCreditRepository.GetAsync(x => x.CustomerId == request.Id);
                    var customerFindex = new FindeksCredit
                    {
                        Id = findexByCustomerId.Id,
                        CustomerId = findexByCustomerId.CustomerId,
                        Score = _findeksCreditService.CalcScore(request.FindeksRate)
                    };

                    await _findeksCreditRepository.UpdateAsync(customerFindex);
                }
                return new SuccessResult(Message.SuccessUpdate);
            }
        }
    }
}
