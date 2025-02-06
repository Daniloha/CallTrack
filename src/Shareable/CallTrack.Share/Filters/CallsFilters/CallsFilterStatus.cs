using CallTrack.Share.config;
using CallTrack.Share.enums;
using System;

namespace CallTrack.Share.Filters.CallsFilters
{
    public class CallsFilterStatus : PagedParameters<SortableCallsFields>
    {
        public int CallsStatus { get; set; }
    }
}
