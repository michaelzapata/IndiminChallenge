using Dapper;
using Indimin.Challenge.Tasking.API.Application.Configurations;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Indimin.Challenge.Tasking.API.Application.Queries
{
    public class CitizenTaskQuery : ICitizenTaskQuery
    {
        private string _connectionString = string.Empty;
        public CitizenTaskQuery(IOptions<DatabaseSettingsOptions> options)
        {
            _ = options ?? throw new System.ArgumentNullException(nameof(options));
            _connectionString =
                !string.IsNullOrEmpty(options.Value.ConnectionString) && !string.IsNullOrWhiteSpace(options.Value.ConnectionString) ?
                options.Value.ConnectionString : throw new System.ArgumentNullException(nameof(options.Value.ConnectionString));
        }

        public async Task<IEnumerable<GetCitizenTaskQueryResponse>> GetCitizenTaskByCitizenIdAsync(string citizenId, CancellationToken cancellationToken = default)
        {
            using var connection = new SqlConnection(_connectionString);

            var lookup = new Dictionary<long, GetCitizenTaskQueryResponse>();

            await connection.QueryAsync<GetCitizenTaskQueryResponse, Domain.Models.DayOfWeek, GetCitizenTaskQueryResponse>(@"
				SELECT [CT].[Id]
				  ,[CT].[CitizenId]
				  ,[CT].[Description]
				  ,[CT].[IsActive]
				  ,[DoW].[Id]
				  ,[DoW].[Name]
			  FROM [IndiminChallengeDB].[IndiminChallenge].[CitizenTask] AS [CT]
			  INNER JOIN [IndiminChallengeDB].[IndiminChallenge].[DayOfWeek] AS [DoW] ON [DoW].[Id] = [CT].[DayOfWeek]
			  WHERE [CT].[CitizenId] = @citizenId

			", (gctqr, dow) =>
            {
                if (!lookup.TryGetValue(gctqr.Id, out GetCitizenTaskQueryResponse response))
                    lookup.Add(gctqr.Id, response = gctqr);

                if (response.DayOfWeek is null)
                    response.DayOfWeek = dow;

                return response;
            }, param: new { citizenId }, splitOn: "Id, Id");

            return lookup.Values.ToList();
        }

        public async Task<IEnumerable<GetCitizenTaskQueryResponse>> GetCitizenTaskByDayOfWeekAsync(int dayOfWeek, CancellationToken cancellationToken = default)
        {
            using var connection = new SqlConnection(_connectionString);

            var lookup = new Dictionary<long, GetCitizenTaskQueryResponse>();

            await connection.QueryAsync<GetCitizenTaskQueryResponse, Domain.Models.DayOfWeek, GetCitizenTaskQueryResponse>(@"
				SELECT [CT].[Id]
				  ,[CT].[CitizenId]
				  ,[CT].[Description]
				  ,[CT].[IsActive]
				  ,[DoW].[Id]
				  ,[DoW].[Name]
			  FROM [IndiminChallengeDB].[IndiminChallenge].[CitizenTask] AS [CT]
			  INNER JOIN [IndiminChallengeDB].[IndiminChallenge].[DayOfWeek] AS [DoW] ON [DoW].[Id] = [CT].[DayOfWeek]
			  WHERE [DoW].[Id] = @dayOfWeek

			", (gctqr, dow) =>
            {
                if (!lookup.TryGetValue(gctqr.Id, out GetCitizenTaskQueryResponse response))
                    lookup.Add(gctqr.Id, response = gctqr);

                if (response.DayOfWeek is null)
                    response.DayOfWeek = dow;

                return response;
            }, param: new { dayOfWeek }, splitOn: "Id, Id");

            return lookup.Values.ToList();
        }

        public async Task<IEnumerable<Domain.Models.DayOfWeek>> GetDayOfWeeksAsync(CancellationToken cancellationToken = default)
        {
            using var connection = new SqlConnection(_connectionString);

            var result = await connection.QueryAsync<Domain.Models.DayOfWeek>(@"
                SELECT
                   [DoW].[Id]
				  ,[DoW].[Name]
                FROM [IndiminChallengeDB].[IndiminChallenge].[DayOfWeek] AS [DoW]
            ");

            return result;
        }
    }
}
