using Indimin.Challenge.Tasking.Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Indimin.Challenge.Tasking.API.Application.Queries
{
    public class GetCitizenTasksQueryResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DayOfWeek DayOfWeek { get; init; }
        public IEnumerable<GetCitizenTaskQueryResponse> CitizenTasks { get; init; }
    }
}
