using CallTrack.Domain.entities;
using CallTrack.Share.config;
using CallTrack.Share.enums;

namespace CallTrack.Domain.services.repositories
{
    public interface IReasonsRepository : IRepository<Reasons>
    {
        Task<PagedList<Reasons>> GetAllPagedAsync(PagedParameters<SortableReasonsFields> parameters);

    }
}
