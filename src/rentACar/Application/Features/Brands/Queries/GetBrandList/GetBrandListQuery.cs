﻿using Application.Constants;
using Application.Features.Brands.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Brands.Queries.GetBrandList
{
    public class GetBrandListQuery : IRequest<IDataResult<BrandListModel>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetBrandListQueryHandler : IRequestHandler<GetBrandListQuery, IDataResult<BrandListModel>>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public GetBrandListQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<BrandListModel>> Handle(GetBrandListQuery request, CancellationToken cancellationToken)
            {
                var brands = await _brandRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );
                var mappedBrand = _mapper.Map<BrandListModel>(brands);

                return new SuccessDataResult<BrandListModel>(mappedBrand, Message.SuccessGet);
            }
        }
    }
}
