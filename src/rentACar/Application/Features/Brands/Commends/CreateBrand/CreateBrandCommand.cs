using Application.Constants;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Logging;
using Core.Mailing;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.Brands.Commends.CreateBrand
{
    public class CreateBrandCommand : IRequest<IDataResult<Brand>>, ILoggableRequest
    {
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, IDataResult<Brand>>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;
            private IMailService _mailService;

            public CreateBrandCommandHandler(IBrandRepository brandRepository, BrandBusinessRules brandBusinessRules, IMapper mapper, IMailService mailService)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
                _mailService = mailService;
            }

            public async Task<IDataResult<Brand>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);
                Brand mappedBrand = _mapper.Map<Brand>(request);
                Brand brandToAdd = await _brandRepository.AddAsync(mappedBrand);

                //Mail mail = new Mail
                //{
                //    ToFullName = "Engin Demiroğ",
                //    ToEmail = "Admins@mng.com.tr",
                //    Subject = "New Brand Added",
                //    HtmlBody = "Hey, check the sistem"
                //};
                //_mailService.SendMail(mail);

                return new SuccessDataResult<Brand>(brandToAdd, Message.SuccessCreate);
            }
        }
    }
}
//Cqrs de her şey domain nesnesi açısından gider. Bu işi yapacak domain nesnemize karşılık gelir.
//Mediatr Patternleri kullanır. Btk da C# dersini izle.
//Code Generater nedir.