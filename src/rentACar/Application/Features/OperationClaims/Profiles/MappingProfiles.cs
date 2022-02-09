using Application.Features.OperationClaims.Commands.CreateClaim;
using Application.Features.OperationClaims.Commands.DeleteClaim;
using Application.Features.OperationClaims.Commands.UpdateClaim;
using AutoMapper;
using Core.Security.Entities;

namespace Application.Features.OperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
        }
    }
}
