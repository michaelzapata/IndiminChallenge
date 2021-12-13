using Indimin.Challenge.BFF.APIs;
using Indimin.Challenge.BFF.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.BFF.Services
{
    public class BFFService : IBFFService
    {
        private readonly CitizensClient _citizensClient;
        private readonly CitizenTasksClient _citizenTasksClient;

        public BFFService(CitizensClient citizensClient, CitizenTasksClient citizenTasksClient)
        {
            _citizensClient = citizensClient ?? throw new ArgumentNullException(nameof(citizensClient));
            _citizenTasksClient = citizenTasksClient ?? throw new ArgumentNullException(nameof(citizenTasksClient));
        }

        public async Task<CitizenTaskDataResponse> GetCitizenTasksByDayOfWeek(int dayOfWeek, CancellationToken cancellationToken = default)
        {
            GetCitizensQueryResponse getCitizensQueryResponse = await _citizensClient.CitizensGETAllAsync();

            GetCitizenTasksQueryResponse getCitizenTaskQueryResponse = await _citizenTasksClient.DayOfWeekAsync(dayOfWeek, cancellationToken);

            CitizenTaskDataResponse response = new CitizenTaskDataResponse
            {
                DayOfWeekData = new DayOfWeekData
                {
                    Id = getCitizenTaskQueryResponse.DayOfWeek.Id,
                    Name = getCitizenTaskQueryResponse.DayOfWeek.Name
                },
                CitizenTasks = new List<CitizenTaskData>()
            };

            foreach (var citizen in getCitizensQueryResponse.Citizens)
            {
                var citizenData = new CitizenData { CitizenId = citizen.Id, CitizenName = citizen.FullName };
                var tasks = getCitizenTaskQueryResponse.CitizenTasks
                    .Where(x => x.CitizenId == citizen.Id)
                    .Select(x => x.Description)
                    .ToList();

                var citizenTasks = new CitizenTaskData { Citizen = citizenData, Tasks = tasks };

                ((List<CitizenTaskData>)response.CitizenTasks).Add(citizenTasks);
            }
            return response;


        }


        public async Task<IEnumerable<DayOfWeekData>> GetDaysOfWeek(CancellationToken cancellationToken = default)
        {
            GetDaysOfWeekQueryResponse getDaysOfWeekQueryResponse = await _citizenTasksClient.DayOfWeekAllAsync(cancellationToken);

            return getDaysOfWeekQueryResponse.DaysOfWeek.Select(x => new DayOfWeekData { Id = x.Id, Name = x.Name }).ToList();
        }
    }
}
