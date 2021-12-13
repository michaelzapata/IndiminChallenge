using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.Tasking.API.Application.Queries
{
    public class GetCitizenTasksByCitizenIdQueryHandler : IRequestHandler<GetCitizenTasksByCitizenIdQuery, GetCitizenTasksQueryResponse>
    {
        private readonly ICitizenTaskQuery _citizenTaskQuery;

        public GetCitizenTasksByCitizenIdQueryHandler(ICitizenTaskQuery citizenTaskQuery)
        {
            _citizenTaskQuery = citizenTaskQuery ?? throw new ArgumentNullException(nameof(citizenTaskQuery));
        }

        public async Task<GetCitizenTasksQueryResponse> Handle(GetCitizenTasksByCitizenIdQuery request, CancellationToken cancellationToken)
        {
            var citizenTasks = await _citizenTaskQuery.GetCitizenTaskByCitizenIdAsync(request.CitizenId, cancellationToken);

            return new GetCitizenTasksQueryResponse { CitizenTasks = citizenTasks };
        }
    }
}
