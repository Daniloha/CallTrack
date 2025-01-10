using CallTrack.Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace CallTrack.Data.repositories.Implementations
{

    public class CallsRepository : ICallsRepository
    {
        protected readonly CallTrackContext _context;

        public CallsRepository(CallTrackContext context)
        {
            _context = context;
        }
        public Task<Calls> CreateAsync(Calls entity)
        {
            throw new NotImplementedException();
        }

        public Calls Delete(Calls entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Calls>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Calls?> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Calls> GetCallById(long id)
        {
            var entity = await _context.Set<Calls>().FirstOrDefaultAsync(x => x.CallId == id);
            if(entity == null) return null!;

            return entity;
        }
        

        public Calls Update(Calls entity)
        {
            throw new NotImplementedException();
        }
    }
}
