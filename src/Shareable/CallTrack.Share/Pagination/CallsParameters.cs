using CallTrack.Share.enums;

namespace CallTrack.Share.config
{
    public class CallsParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public SortableFields OrderBy { get; set; } // Campo para ordenação
        public bool Descending { get; set; } // Ordem decrescente
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }


    }
}
