using Application.Features.SizeOperations.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.SizeOperations.Profiles;

public class MappingProfiles : Profile
{
     public MappingProfiles()
     {
          CreateMap<Size, GetSizesQueryResponse>().ReverseMap();
     }
}

