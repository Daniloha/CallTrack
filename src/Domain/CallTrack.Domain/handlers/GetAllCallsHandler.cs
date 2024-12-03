using CallTrack.Share.requests;
using CallTrack.Domain.services.repositoriesories;
using MediatR;

namespace CallTrack.Domain.handlers
{
    public class GetAllCallsHandler : IRequestHandler<GetAllCallsRequest>
    {

        private readonly IRepository _repository;
        private readonly CallProfile _mapper;
        public Task Handle(GetAllCallsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
