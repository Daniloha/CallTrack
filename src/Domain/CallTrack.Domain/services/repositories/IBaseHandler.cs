using AutoMapper;

namespace CallTrack.Domain.services.repositories
{
    public interface IBaseHandler<TRepository>
    {
        TRepository Repository { get; }
        IMapper Mapper { get; }
    }

}
