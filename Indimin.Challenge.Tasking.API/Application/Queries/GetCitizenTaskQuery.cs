using MediatR;

namespace Indimin.Challenge.Tasking.API.Application.Queries
{
    public class GetCitizenTaskQuery : IRequest<GetCitizenTaskQueryResponse>
    {
        public long Id { get; init; }
    }
}
