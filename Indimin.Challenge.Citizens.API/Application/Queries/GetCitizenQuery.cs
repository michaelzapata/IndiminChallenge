using MediatR;

namespace Indimin.Challenge.Citizens.API.Application.Queries
{
    public class GetCitizenQuery : IRequest<GetCitizenQueryResponse>
    {
        public string Id { get; init; }
    }
}
