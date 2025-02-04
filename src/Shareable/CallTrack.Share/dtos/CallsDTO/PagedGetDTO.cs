using CallTrack.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTrack.Share.dtos.CallsDTO
{
    public class PagedGetDTO<T>
    {
        public List<T> Items { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }

        public PagedGetDTO(PagedList<T> pagedList)
        {
            Items = pagedList.ToList();
            CurrentPage = pagedList.CurrentPage;
            TotalPages = pagedList.TotalPages;
            PageSize = pagedList.PageSize;
            TotalCount = pagedList.TotalCount;
            HasPrevious = pagedList.HasPrevious;
            HasNext = pagedList.HasNext;
        }
    }
}
