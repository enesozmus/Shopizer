using Application.Features.BrandOperations.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.BrandOperations.Profiles;

public class MappingProfiles : Profile
{
     public MappingProfiles()
     {
          CreateMap<Brand, GetBrandsQueryResponse>().ReverseMap();
     }
}

