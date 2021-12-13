using MediatR;

namespace Indimin.Challenge.Tasking.API.Application.Queries
{
    public class GetCitizenTasksByCitizenIdQuery : IRequest<GetCitizenTasksQueryResponse>
    {
        public string CitizenId { get; init; }
    }
}
