using CallTrack.Domain.entities;
using CallTrack.Domain.services.repositories;
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

        Task<Calls> IRepository<Calls>.UpdateAsync(Calls entity)
        {
            _context.Set<Calls>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return Task.FromResult(entity);
        }
    }
}
