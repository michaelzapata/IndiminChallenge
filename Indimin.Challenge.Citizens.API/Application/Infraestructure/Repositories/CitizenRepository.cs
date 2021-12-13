using Indimin.Challenge.Citizens.API.Application.Entities;
using Indimin.Challenge.Citizens.API.Application.Infraestructure.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.Citizens.API.Application.Infraestructure.Repositories
{
    public class CitizenRepository : ICitizenRepository
    {
        private readonly ICitizenContext _citizenContext;

        public CitizenRepository(ICitizenContext citizenContext)
        {
            _citizenContext = citizenContext ?? throw new ArgumentNullException(nameof(citizenContext));
        }

        public async Task CreateCitizenAsync(Citizen citizen, CancellationToken cancellationToken = default)
        {
            await _citizenContext.Citizens.InsertOneAsync(citizen, cancellationToken: cancellationToken);
        }

        public async Task<bool> DeleteCitizenAsync(string id, CancellationToken cancellationToken = default)
        {

            var citizen = await GetCitizenAsync(id, cancellationToken);
            citizen.IsActive = false;

            return await UpdateCitizenAsync(citizen, cancellationToken);
        }

        public async Task<Citizen> GetCitizenAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _citizenContext.Citizens
                .Find(props => props.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Citizen>> GetCitizensAsync(CancellationToken cancellationToken = default)
        {
            return await _citizenContext.Citizens.Find(x => true).ToListAsync(cancellationToken);
        }

        public async Task<bool> UpdateCitizenAsync(Citizen citizen, CancellationToken cancellationToken = default)
        {
            var updateResult = await _citizenContext.Citizens
                .ReplaceOneAsync(filter: g => g.Id == citizen.Id, replacement: citizen);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
