using CallTrack.Domain.entities;
using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.vos;

namespace CallTrack.Share.responses.ReasonsResponse
{
    public class GetAllReasonsResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public PagedGetDTO<ReasonsVO> Data { get; set; }

        public GetAllReasonsResponse(PagedList<ReasonsVO> pagedList, string message = "Consulta realizada com sucesso")
        {
            Success = true;
            Message = message;
            Data = new PagedGetDTO<ReasonsVO>(pagedList);
        }
    }
}