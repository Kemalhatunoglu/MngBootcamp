using Application.Constants;
using Application.Features.Transmissions.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Transmissions.Queries.GetTransmissionList
{
    public class GetTransmissionListQuery : IRequest<IDataResult<TransmissionListModel>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetTransmissionListQueryHandler : IRequestHandler<GetTransmissionListQuery, IDataResult<TransmissionListModel>>
        {
            private readonly ITransmissionRepository _transmissionRepository;
            private readonly IMapper _mapper;

            public GetTransmissionListQueryHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
            {
                _transmissionRepository = transmissionRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<TransmissionListModel>> Handle(GetTransmissionListQuery request, CancellationToken cancellationToken)
            {
                var transmissions = await _transmissionRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );
                var mappedTransmission = _mapper.Map<TransmissionListModel>(transmissions);

                return new SuccessDataResult<TransmissionListModel>(mappedTransmission, Message.SuccessGet);
            }
        }
    }
}
