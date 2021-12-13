using Indimin.Challenge.Citizens.API.Application.Entities;
using MongoDB.Driver;

namespace Indimin.Challenge.Citizens.API.Application.Infraestructure.Contracts
{
    public interface ICitizenContext
    {
        IMongoCollection<Citizen> Citizens { get; }
    }
}
