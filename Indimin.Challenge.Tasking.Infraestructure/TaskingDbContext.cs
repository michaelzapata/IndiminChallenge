using Indimin.Challenge.Tasking.Domain.Contracts;
using Indimin.Challenge.Tasking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.Tasking.Infraestructure
{
    public class TaskingDbContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "IndiminChallenge";

        public DbSet<CitizenTask> CitizenTasks { get; set; }

        public DbSet<DayOfWeek> DayOfWeeks { get; set; }

        public TaskingDbContext(DbContextOptions<TaskingDbContext> options) : base(options) { }
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
