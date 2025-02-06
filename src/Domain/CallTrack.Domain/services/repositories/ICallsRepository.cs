using CallTrack.Domain.entities;
using CallTrack.Domain.services.repositories;
using CallTrack.Share.config;
using CallTrack.Share.Filters;
using CallTrack.Share.enums;
using CallTrack.Share.Filters.CallsFilters;

namespace CallTrack.Data.repositories
{
    public interface ICallsRepository : IRepository<Calls>
    {
        Task<PagedList<Calls>> GetCallsAsync(CallsParameters callsParameters);
        Task<PagedList<Calls>> GetCallsAsync(PagedParameters<SortableCallsFields> callsParameters);
        Task<PagedList<Calls>> GetCallsFilterAnalyst(CallsFilterAnalyst callsFilterAnalyst);
        Task<PagedList<Calls>> GetCallsFilterReason(CallsFilterReason callsFilterReason);
        Task<PagedList<Calls>> GetCallsFilterType(CallsFilterType callsFilterType);
        Task<PagedList<Calls>> GetCallsFilterStatus(CallsFilterStatus callsFilterStatus);
        Task<PagedList<Calls>> GetCallsFilterPeriod(CallsFilterPeriod callsFilterPeriod);
        public Task<Calls> GetCallById(long id);
        //Task GetCallsAsync(CallsParameters callsParameters);
    }
}
