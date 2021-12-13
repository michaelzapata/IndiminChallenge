using Indimin.Challenge.Tasking.Domain.Models;
using System.Collections;
using System.Collections.Generic;

namespace Indimin.Challenge.Tasking.API.Application.Queries
{
    public class GetDaysOfWeekQueryResponse
    {
        public IEnumerable<DayOfWeek> DaysOfWeek { get; init; }
    }
}
