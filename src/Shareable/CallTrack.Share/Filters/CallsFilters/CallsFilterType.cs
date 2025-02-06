using CallTrack.Share.config;
using CallTrack.Share.enums;

namespace CallTrack.Share.Filters.CallsFilters
{
    public class CallsFilterType : PagedParameters<SortableCallsFields>
    {
        public int CallsType { get; set; }
    }
}
