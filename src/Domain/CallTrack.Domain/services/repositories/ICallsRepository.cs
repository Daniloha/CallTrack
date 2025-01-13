using CallTrack.Domain.entities;
using CallTrack.Domain.services.repositories;

namespace CallTrack.Data.repositories
{
    public interface ICallsRepository : IRepository<Calls>
    {
        public Task<Calls> GetCallById(long id);
    }
}
