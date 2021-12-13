using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.Tasking.API.Application.Queries
{
    public class GetDaysOfWeekQueryHandler : IRequestHandler<GetDaysOfWeekQuery, GetDaysOfWeekQueryResponse>
    {
        private readonly ICitizenTaskQuery _citizenTaskQuery;

        public GetDaysOfWeekQueryHandler(ICitizenTaskQuery citizenTaskQuery)
        {
            _citizenTaskQuery = citizenTaskQuery ?? throw new ArgumentNullException(nameof(citizenTaskQuery));
        }

        public async Task<GetDaysOfWeekQueryResponse> Handle(GetDaysOfWeekQuery request, CancellationToken cancellationToken)
        {
            var result = await _citizenTaskQuery.GetDayOfWeeksAsync(cancellationToken);

            return new GetDaysOfWeekQueryResponse { DaysOfWeek = result };
        }
    }
}
