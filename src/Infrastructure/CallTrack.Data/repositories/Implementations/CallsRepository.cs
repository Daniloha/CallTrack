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

        Task<Calls> IRepository<Calls>.UpdateAsync(Calls entity)
        {
            _context.Set<Calls>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return Task.FromResult(entity);
        }
    }
}
