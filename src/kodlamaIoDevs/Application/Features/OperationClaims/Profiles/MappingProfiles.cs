﻿using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Commands.DeleteOperationClaimCommand;
using Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.OperationClaims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();

        CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();
        CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();

        CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
        CreateMap<OperationClaim, OperationClaimGetByIdDto>().ReverseMap();

        CreateMap<OperationClaim, DeletedOperationClaimDto>().ReverseMap();
        CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();

        CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();
        CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();

       

       

        
    }
}