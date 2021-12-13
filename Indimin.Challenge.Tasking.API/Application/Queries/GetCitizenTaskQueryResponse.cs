using Indimin.Challenge.Tasking.Domain.Models;

namespace Indimin.Challenge.Tasking.API.Application.Queries
{
    public class GetCitizenTaskQueryResponse
    {
        public long Id { get; init; }
        public string CitizenId { get; init; }
        public string Description { get; init; }
        public bool IsActive { get; init; }
        public DayOfWeek DayOfWeek { get; set; }
    }
}
