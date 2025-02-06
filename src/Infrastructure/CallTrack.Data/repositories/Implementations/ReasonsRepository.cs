using CallTrack.Domain.entities;
using CallTrack.Domain.services.repositories;
using CallTrack.Share.config;
using CallTrack.Share.enums;
using CallTrack.Share.Sort;

namespace CallTrack.Data.repositories.Implementations
{
    public class ReasonsRepository : GenericRepository<Reasons>, IReasonsRepository
    {
        public ReasonsRepository(CallTrackContext context) : base(context) { }

        public async Task<PagedList<Reasons>> GetAllPagedAsync(PagedParameters<SortableReasonsFields> parameters)
        {
            var query = _context.Reasons.AsQueryable();

            // Aplicando ordenação
            if (parameters.OrderBy != null)
            {
                query = query.ApplySorting(parameters.OrderBy.ToString(), parameters.Descending);
            }

            // Aplicando paginação
            return await Task.FromResult(PagedList<Reasons>.ToPagedList(query, parameters.PageNumber, parameters.PageSize));
        }
    }
}
