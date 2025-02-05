using CallTrack.Share.config;
using CallTrack.Share.enums;

namespace CallTrack.Share.Filters.CallsFilters
{
    public class CallsFilterReason : PagedParameters<SortableCallsFields>
    {
        public long Id { get; set; }
    }
}
