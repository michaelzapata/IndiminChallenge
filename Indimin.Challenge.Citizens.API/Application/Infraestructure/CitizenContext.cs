using Indimin.Challenge.Citizens.API.Application.Entities;
using Indimin.Challenge.Citizens.API.Application.Infraestructure.Contracts;
using Indimin.Challenge.Citizens.API.Application.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace Indimin.Challenge.Citizens.API.Application.Infraestructure
{
    public class CitizenContext : ICitizenContext
    {
        public CitizenContext(IOptions<DatabaseSettingsOptions> options)
        {
            _ = options ?? throw new ArgumentNullException(nameof(options));
            DatabaseSettingsOptions optionsValue = options.Value ?? throw new Exception(nameof(options.Value));

            var client = new MongoClient(optionsValue.ConnectionString);
            var database = client.GetDatabase(optionsValue.DatabaseName);

            Citizens = database.GetCollection<Citizen>(optionsValue.CollectionName);

            var keys = Builders<Citizen>.IndexKeys.Ascending(x => x.FirstName).Ascending( x => x.LastName);

            var indexOptions = new CreateIndexOptions { Unique = true };

            var model = new CreateIndexModel<Citizen>(keys, indexOptions);

            Citizens.Indexes.CreateOne(model);
            
        }
        public IMongoCollection<Citizen> Citizens { get; }
    }
}
