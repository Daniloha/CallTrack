using CallTrack.Domain.entities;
using CallTrack.Domain.services.repositories;

namespace CallTrack.Data.repositories.Implementations
{
    public class ReasonsRepository : GenericRepository<Reasons>, IReasonsRepository
    {
        public ReasonsRepository(CallTrackContext context) : base(context) { }
    }
}
