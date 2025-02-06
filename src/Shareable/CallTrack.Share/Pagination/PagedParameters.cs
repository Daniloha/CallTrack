using CallTrack.Share.enums;
using System;

namespace CallTrack.Share.config
{
    public class PagedParameters<TEnum> where TEnum : Enum
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public TEnum? OrderBy { get; set; } // Campo para ordenação
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
