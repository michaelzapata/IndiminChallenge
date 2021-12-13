using Indimin.Challenge.BFF.Services.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.BFF.Services
{
    public interface IBFFService
    {
        Task<IEnumerable<DayOfWeekData>> GetDaysOfWeek(CancellationToken cancellationToken = default);
        Task<CitizenTaskDataResponse> GetCitizenTasksByDayOfWeek(int dayOfWeek, CancellationToken cancellationToken = default);
    }
}
