using Application.Features.Color.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Color.Queries.GetColorList
{
    public class GetColorListQuery : IRequest<ColorListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetColorListQueryHandler : IRequestHandler<GetColorListQuery, ColorListModel>
        {
            private readonly IColorRepository _colorRepository;
            private readonly IMapper _mapper;

            public GetColorListQueryHandler(IMapper mapper, IColorRepository colorRepository)
            {
                _mapper = mapper;
                _colorRepository = colorRepository;
            }

            public async Task<ColorListModel> Handle(GetColorListQuery request, CancellationToken cancellationToken)
            {
                var colors = await _colorRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                var mappedColor = _mapper.Map<ColorListModel>(colors);
                return mappedColor;
            }
        }
    }
}
