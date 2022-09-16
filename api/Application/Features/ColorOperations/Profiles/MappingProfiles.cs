using Application.Features.ColorOperations.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.ColorOperations.Profiles;

public class MappingProfiles : Profile
{
     public MappingProfiles()
     {
          CreateMap<Color, GetColorsQueryResponse>().ReverseMap();
     }
}

