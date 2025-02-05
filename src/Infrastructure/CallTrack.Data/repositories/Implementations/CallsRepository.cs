using CallTrack.Domain.entities;
using CallTrack.Domain.services.repositories;
using CallTrack.Share.config;
using CallTrack.Share.enums;
using CallTrack.Share.Filters.CallsFilters;
using CallTrack.Share.Sort;
using Microsoft.EntityFrameworkCore;

namespace CallTrack.Data.repositories.Implementations
{

    public class CallsRepository : GenericRepository<Calls>, ICallsRepository
    {

        public CallsRepository(CallTrackContext context) : base(context) { }

        public async Task<Calls> GetCallById(long id)
        {
            var entity = await _context.Set<Calls>().FirstOrDefaultAsync(x => x.CallId == id);
            if (entity == null) return null!;

            return entity;
        }
        public async Task<PagedList<Calls>> GetCallsAsync(PagedParameters<SortableCallsFields> callsParameters)
        {
            var query = _context.Set<Calls>().AsQueryable();

            return await Task.Run(() =>
                PagedList<Calls>.ToPagedList(query, callsParameters.PageNumber, callsParameters.PageSize)
            );
        }

        public Task<PagedList<Calls>> GetCallsFilterAnalyst(CallsFilterAnalyst callsFilterAnalyst)
        {
            var calls = _context.Set<Calls>().Where(x => x.AnalystId == callsFilterAnalyst.Id).AsQueryable();
            // Aplicar ordenação genérica
            calls = calls.ApplySorting(callsFilterAnalyst.OrderBy.ToString(), callsFilterAnalyst.Descending);

            return Task.Run(() =>
                PagedList<Calls>.ToPagedList(calls, callsFilterAnalyst.PageNumber, callsFilterAnalyst.PageSize)
            );
        }

        public Task<PagedList<Calls>> GetCallsFilterPeriod(CallsFilterPeriod callsFilterPeriod)
        {
            var calls = _context.Set<Calls>().Where(x => x.OpenDate >= callsFilterPeriod.StartDate && x.CloseDate <= callsFilterPeriod.EndDate).AsQueryable();

            // Aplicar ordenação genérica
            calls = calls.ApplySorting(callsFilterPeriod.OrderBy.ToString(), callsFilterPeriod.Descending);

            return Task.Run(() =>
                PagedList<Calls>.ToPagedList(calls, callsFilterPeriod.PageNumber, callsFilterPeriod.PageSize)
            );
        }

        public Task<PagedList<Calls>> GetCallsFilterReason(CallsFilterReason callsFilterReason)
        {
            var calls = _context.Set<Calls>().Where(x => x.ReasonId == callsFilterReason.Id).AsQueryable();

            // Aplicar ordenação genérica
            calls = calls.ApplySorting(callsFilterReason.OrderBy.ToString(), callsFilterReason.Descending);

            return Task.Run(() =>
                PagedList<Calls>.ToPagedList(calls, callsFilterReason.PageNumber, callsFilterReason.PageSize)
            );
        }

        public Task<PagedList<Calls>> GetCallsFilterStatus(CallsFilterStatus callsFilterStatus)
        {
            var calls = _context.Set<Calls>().Where(x => x.Status == callsFilterStatus.CallsStatus).AsQueryable();

            // Aplicar ordenação genérica
            calls = calls.ApplySorting(callsFilterStatus.OrderBy.ToString(), callsFilterStatus.Descending);

            return Task.Run(() =>
                PagedList<Calls>.ToPagedList(calls, callsFilterStatus.PageNumber, callsFilterStatus.PageSize)
            );
        }

        public Task<PagedList<Calls>> GetCallsFilterType(CallsFilterType callsFilterType)
        {
            var calls = _context.Set<Calls>().Where(x => x.Type == callsFilterType.CallsType).AsQueryable();

            // Aplicar ordenação genérica
            calls = calls.ApplySorting(callsFilterType.OrderBy.ToString(), callsFilterType.Descending);

            return Task.Run(() =>
                PagedList<Calls>.ToPagedList(calls, callsFilterType.PageNumber, callsFilterType.PageSize)
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
