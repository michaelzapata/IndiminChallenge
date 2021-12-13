using AutoMapper;
using Indimin.Challenge.Citizens.API.Application.Commands;
using Indimin.Challenge.Citizens.API.Application.Entities;
using Indimin.Challenge.Citizens.API.Application.Queries;

namespace Indimin.Challenge.Citizens.API.Application.Profiles
{
    public class CitizenProfile : Profile
    {
        public CitizenProfile()
        {
            CreateMap<Citizen, UpdateCitizenCommand>().ReverseMap();
            CreateMap<Citizen, GetCitizenQueryResponse>().ReverseMap();
            CreateMap<Citizen, CreateCitizenCommandResponse>().ReverseMap();
        }
    }
}
