using CallTrack.Share.config;
using CallTrack.Share.enums;

namespace CallTrack.Share.Filters.CallsFilters
{
    public class CallsFilterPeriod : PagedParameters<SortableCallsFields>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
