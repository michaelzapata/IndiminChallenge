using Indimin.Challenge.Tasking.Domain.Contracts;
using Indimin.Challenge.Tasking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indimin.Challenge.Tasking.Infraestructure.Repositories
{
    public class CitizenTaskRepository : ICitizenTaskRepository
    {
        private readonly TaskingDbContext _taskingDbContext;

        public CitizenTaskRepository(TaskingDbContext taskingDbContext)
        {
            _taskingDbContext = taskingDbContext ?? throw new ArgumentNullException(nameof(taskingDbContext));
        }

        public IUnitOfWork UnitOfWork => _taskingDbContext;

        public CitizenTask Add(CitizenTask task)
        {
            return _taskingDbContext.CitizenTasks.Add(task).Entity;
        }

        public async Task Delete(long id)
        {
            var citizenTask = await GetAsync(id);

            citizenTask.DesactivateCitizenTask();

            Update(citizenTask);

        }

        public async Task<CitizenTask> GetAsync(long id)
        {
            var citizenTask = await _taskingDbContext
                                .CitizenTasks
                                .FirstOrDefaultAsync(o => o.Id == id);
            if (citizenTask == null)
            {
                citizenTask = _taskingDbContext
                            .CitizenTasks
                            .Local
                            .FirstOrDefault(o => o.Id == id);
            }

            return citizenTask;
        }

        public async Task<IEnumerable<CitizenTask>> GetsAsync()
        {
            return await _taskingDbContext.CitizenTasks.ToListAsync();
        }

        public void Update(CitizenTask task)
        {
            _taskingDbContext.Entry(task).State = EntityState.Modified;
        }
    }
}
