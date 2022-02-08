using Application.Constants;
using Application.Services.OutService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
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
        public float? FindeksRate { get; set; }

        public class UpdateCorporateCustomerCommandHandler : IRequestHandler<UpdateCorporateCustomerCommand, IResult>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;
            private readonly IFindeksCreditService _findeksCreditService;
            private readonly IFindeksCreditRepository _findeksCreditRepository;

            public UpdateCorporateCustomerCommandHandler(IMapper mapper, ICorporateCustomerRepository corporateCustomerRepository, IFindeksCreditService findeksCreditService, IFindeksCreditRepository findeksCreditRepository)
            {
                _mapper = mapper;
                _corporateCustomerRepository = corporateCustomerRepository;
                _findeksCreditService = findeksCreditService;
                _findeksCreditRepository = findeksCreditRepository;
            }

            public async Task<IResult> Handle(UpdateCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                var updateModelCorporateCustomer = _mapper.Map<Domain.Entities.Concete.CorporateCustomer>(request);
                await _corporateCustomerRepository.UpdateAsync(updateModelCorporateCustomer);
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
