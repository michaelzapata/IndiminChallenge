using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.Tasking.API.Application.Queries
{
    public class GetCitizenTasksByDayOfWeekQueryHandler : IRequestHandler<GetCitizenTasksByDayOfWeekQuery, GetCitizenTasksQueryResponse>
    {
        private readonly ICitizenTaskQuery _citizenTaskQuery;

        public GetCitizenTasksByDayOfWeekQueryHandler(ICitizenTaskQuery citizenTaskQuery)
        {
            _citizenTaskQuery = citizenTaskQuery ?? throw new ArgumentNullException(nameof(citizenTaskQuery));
        }

        public async Task<GetCitizenTasksQueryResponse> Handle(GetCitizenTasksByDayOfWeekQuery request, CancellationToken cancellationToken)
        {
            var citizenTasks = await _citizenTaskQuery.GetCitizenTaskByDayOfWeekAsync(request.DayOfWeek, cancellationToken);

            return new GetCitizenTasksQueryResponse { DayOfWeek = Indimin.Challenge.Tasking.Domain.Models.DayOfWeek.From(request.DayOfWeek), CitizenTasks = citizenTasks };
        }
    }
}
