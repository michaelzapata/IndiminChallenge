using Indimin.Challenge.Tasking.Domain.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Indimin.Challenge.Tasking.Domain.Models
{
    public interface ICitizenTaskRepository : IRepository<CitizenTask>
    {
        CitizenTask Add(CitizenTask task);
        void Update(CitizenTask task);
        Task Delete(long id);
        Task<CitizenTask> GetAsync(long id);
        Task<IEnumerable<CitizenTask>> GetsAsync();
    }
}
