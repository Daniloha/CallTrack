using AutoMapper;
using CallTrack.Domain.services.repositories;

namespace CallTrack.Domain.handlers.CallsHandler
{
    public abstract class BaseHandler<TRepository> : IBaseHandler<TRepository>
    {
        public TRepository Repository { get; }
        public IMapper Mapper { get; }

        protected BaseHandler(TRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }
    }
}
