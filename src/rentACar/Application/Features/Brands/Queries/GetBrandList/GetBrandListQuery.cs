﻿using Application.Features.Brands.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Brands.Queries.GetBrandList
{
    public class GetBrandListQuery : IRequest<BrandListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetBrandListQueryHandler : IRequestHandler<GetBrandListQuery, BrandListModel>
        {
            readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public GetBrandListQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<BrandListModel> Handle(GetBrandListQuery request, CancellationToken cancellationToken)
            {
                var brands = await _brandRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );
                var mappedBrand = _mapper.Map<BrandListModel>(brands);

                return mappedBrand;
            }
        }
    }
}