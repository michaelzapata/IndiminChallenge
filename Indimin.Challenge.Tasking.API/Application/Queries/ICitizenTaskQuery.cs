using Indimin.Challenge.Tasking.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.Tasking.API.Application.Queries
{
    public interface ICitizenTaskQuery
    {
        Task<IEnumerable<GetCitizenTaskQueryResponse>> GetCitizenTaskByDayOfWeekAsync(int dayOfWeek, CancellationToken cancellationToken = default);
        Task<IEnumerable<GetCitizenTaskQueryResponse>> GetCitizenTaskByCitizenIdAsync(string citizenId, CancellationToken cancellationToken = default);
        Task<IEnumerable<DayOfWeek>> GetDayOfWeeksAsync(CancellationToken cancellationToken = default);
    }
}
