using Indimin.Challenge.Citizens.API.Application.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.Citizens.API.Application.Infraestructure.Contracts
{
    public interface ICitizenRepository
    {
        Task<IEnumerable<Citizen>> GetCitizensAsync(CancellationToken cancellationToken = default);
        Task<Citizen> GetCitizenAsync(string id, CancellationToken cancellationToken = default);        
        Task CreateCitizenAsync(Citizen citizen, CancellationToken cancellationToken = default);
        Task<bool> UpdateCitizenAsync(Citizen citizen, CancellationToken cancellationToken = default);
        Task<bool> DeleteCitizenAsync(string id, CancellationToken cancellationToken = default);
    }
}
