using System.Linq;
using AutoMapper;
using CallTrack.Domain.entities;
using CallTrack.Share.dtos.CallsDTO;

public static class PagedListExtensions
{
    public static PagedList<TDestination> MapPagedList<TSource, TDestination>(this PagedList<TSource> source, IMapper mapper)
    {
        var mappedItems = source.Select(item => mapper.Map<TDestination>(item)).ToList();
        return new PagedList<TDestination>(mappedItems, source.TotalCount, source.CurrentPage, source.PageSize);
    }
}