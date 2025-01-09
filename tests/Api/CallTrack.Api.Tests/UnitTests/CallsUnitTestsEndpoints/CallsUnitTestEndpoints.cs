using AutoMapper;
using CallTrack.Data;
using CallTrack.Data.repositories.Implementations;
using CallTrack.Domain.entities;
using CallTrack.Domain.services.repositories;
using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.vos;
using Microsoft.EntityFrameworkCore;

namespace CallTrack.Api.Tests.UnitTests.CallsUnitTestsEndpoints
{
    public class CallsUnitTestEndpoints
    {
        public IRepository<Calls> _repository { get; set; }
        public IMapper _mapper { get; set; }
        public static DbContextOptions<CallTrackContext> dbContextOptions { get; }

        public static string ConnectionString =
            "Server=localhost;Database=CallTrackDb;User Id=farmacia;Password=12345";

        static CallsUnitTestEndpoints()
        {
            dbContextOptions = new DbContextOptionsBuilder<CallTrackContext>()
                .UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString))
                .Options;
        }

        public static CallsUnitTestEndpoints Create()
        {
            var context = new CallTrackContext(dbContextOptions);
            var repository = new GenericRepository<Calls>(context);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PostCallsDTO, Calls>();
                cfg.CreateMap<Calls, CallsVO>();
            });

            var mapper = config.CreateMapper();

            return new CallsUnitTestEndpoints
            {
                _repository = repository,
                _mapper = mapper
            };
        }
    }

}
