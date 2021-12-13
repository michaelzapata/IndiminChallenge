using System.Collections.Generic;

namespace Indimin.Challenge.BFF.Services.Entities
{
    public class CitizenTaskDataResponse
    {
        public DayOfWeekData DayOfWeekData { get; init; }
        public IEnumerable<CitizenTaskData> CitizenTasks { get; init; }
    }

    public class CitizenTaskData
    {
        public CitizenData Citizen { get; init; }
        public IEnumerable<string> Tasks { get; init; }
    }
}
