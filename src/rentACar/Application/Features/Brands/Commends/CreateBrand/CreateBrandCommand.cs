using Application.Constants;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Mailing;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.Brands.Commends.CreateBrand
{
    public class CreateBrandCommand : IRequest<IDataResult<BrandCommandDto>>
    {
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, IDataResult<BrandCommandDto>>
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

            public async Task<IDataResult<BrandCommandDto>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);
                Brand mappedBrand = _mapper.Map<Brand>(request);
                Brand brandToAdd = await _brandRepository.AddAsync(mappedBrand);
                var mapToDto = _mapper.Map<BrandCommandDto>(brandToAdd);

                #region MailAdded
                //Mail mail = new Mail
                //{
                //    ToFullName = "Engin Demiroğ",
                //    ToEmail = "Admins@mng.com.tr",
                //    Subject = "New Brand Added",
                //    HtmlBody = "Hey, check the sistem"
                //};
                //_mailService.SendMail(mail);
                #endregion

                return new SuccessDataResult<BrandCommandDto>(mapToDto, Message.SuccessCreate);
            }
        }
    }
}