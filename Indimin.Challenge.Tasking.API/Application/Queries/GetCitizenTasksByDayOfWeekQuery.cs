using MediatR;

namespace Indimin.Challenge.Tasking.API.Application.Queries
{
    public class GetCitizenTasksByDayOfWeekQuery : IRequest<GetCitizenTasksQueryResponse>
    {
        public int DayOfWeek { get; init; }
    }
}
