using CallTrack.Domain.entities;
using CallTrack.Domain.services.repositories;
using CallTrack.Share.config;

namespace CallTrack.Data.repositories
{
    public interface ICallsRepository : IRepository<Calls>
    {
        Task<PagedList<Calls>> GetCallsAsync(CallsParameters callsParameters);
        public Task<Calls> GetCallById(long id);
        //Task GetCallsAsync(CallsParameters callsParameters);
    }
}
