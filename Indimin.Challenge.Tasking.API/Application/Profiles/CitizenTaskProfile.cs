using AutoMapper;
using Indimin.Challenge.Tasking.API.Application.Commands;
using Indimin.Challenge.Tasking.API.Application.Queries;
using Indimin.Challenge.Tasking.Domain.Models;

namespace Indimin.Challenge.Tasking.API.Application.Profiles
{
    public class CitizenTaskProfile : Profile
    {
        public CitizenTaskProfile()
        {
            CreateMap<CitizenTask, CreateCitizenTaskCommandResponse>().ReverseMap();
            CreateMap<CitizenTask, GetCitizenTaskQueryResponse>().ReverseMap();
        }
    }
}
