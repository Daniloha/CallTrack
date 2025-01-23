using CallTrack.Domain.entities;
using CallTrack.Domain.services.repositories;
using CallTrack.Share.config;
using CallTrack.Share.Pagination;
using Microsoft.EntityFrameworkCore;

namespace CallTrack.Data.repositories.Implementations
{

    public class CallsRepository : GenericRepository<Calls>, ICallsRepository
    {

        public CallsRepository(CallTrackContext context) : base(context) { }

        public async Task<Calls> GetCallById(long id)
        {
            var entity = await _context.Set<Calls>().FirstOrDefaultAsync(x => x.CallId == id);
            if(entity == null) return null!;

            return entity;
        }
        public async Task<PagedList<Calls>> GetCallsAsync(CallsParameters callsParameters)
        {
            var query = _context.Set<Calls>().AsQueryable();

            return await Task.Run(() =>
                PagedList<Calls>.ToPagedList(query, callsParameters.PageNumber, callsParameters.PageSize)
            );
        }

        public Task<PagedList<Calls>> GetCallsFilterAnalyst(CallsFilterAnalyst callsFilterAnalyst)
        {
            var Calls = _context.Set<Calls>().Where(x => x.AnalystId == callsFilterAnalyst.Id).AsQueryable();

            return Task.Run(() =>
                PagedList<Calls>.ToPagedList(Calls, callsFilterAnalyst.PageNumber, callsFilterAnalyst.PageSize)
            );
        }

        public Task<PagedList<Calls>> GetCallsFilterPeriod(CallsFilterPeriod callsFilterPeriod)
        {
            var Calls = _context.Set<Calls>().Where(x => x.OpenDate >= callsFilterPeriod.StartDate && x.CloseDate <= callsFilterPeriod.EndDate).AsQueryable();

            return Task.Run(() =>
                PagedList<Calls>.ToPagedList(Calls, callsFilterPeriod.PageNumber, callsFilterPeriod.PageSize)
            );
        }

        public Task<PagedList<Calls>> GetCallsFilterReason(CallsFilterReason callsFilterReason)
        {
            var Calls = _context.Set<Calls>().Where(x => x.ReasonId == callsFilterReason.Id).AsQueryable();

            return Task.Run(() =>
                PagedList<Calls>.ToPagedList(Calls, callsFilterReason.PageNumber, callsFilterReason.PageSize)
            );
        }

        public Task<PagedList<Calls>> GetCallsFilterStatus(CallsFilterStatus callsFilterStatus)
        {
            var Calls = _context.Set<Calls>().Where(x => x.Status == callsFilterStatus.CallsStatus).AsQueryable();

            return Task.Run(() =>
                PagedList<Calls>.ToPagedList(Calls, callsFilterStatus.PageNumber, callsFilterStatus.PageSize)
            );
        }

        public Task<PagedList<Calls>> GetCallsFilterType(CallsFilterType callsFilterType)
        {
            var Calls = _context.Set<Calls>().Where(x => x.Type == callsFilterType.CallsType).AsQueryable();

            return Task.Run(() =>
                PagedList<Calls>.ToPagedList(Calls, callsFilterType.PageNumber, callsFilterType.PageSize)
            );
        }

        Task<Calls> IRepository<Calls>.UpdateAsync(Calls entity)
        {
            _context.Set<Calls>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return Task.FromResult(entity);
        }
    }
}
