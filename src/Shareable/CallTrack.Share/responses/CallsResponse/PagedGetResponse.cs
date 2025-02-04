using CallTrack.Domain.entities;
using CallTrack.Share.dtos.CallsDTO;

namespace CallTrack.Share.responses.CallsResponse
{
    public class PagedGetResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public PagedGetDTO<T> Data { get; set; }

        public PagedGetResponse(PagedList<T> pagedList, string message = "Consulta realizada com sucesso")
        {
            Success = true;
            Message = message;
            Data = new PagedGetDTO<T>(pagedList);
        }
    }
}
