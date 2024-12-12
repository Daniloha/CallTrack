using CallTrack.Data;
using CallTrack.Data.repositories.Implementations;
using CallTrack.Domain.services.Mappings.CallsProfile;
using CallTrack.Domain.services.repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;



namespace CallTrack.Api.extensions
{
    public static class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddApiSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();
            return builder;
        }
            public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
        public static WebApplicationBuilder AddPersistence(
             this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration
                       .GetConnectionString("DefaultConnection");

                builder.Services.AddDbContext<CallTrackContext>(options =>
                    options
                        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                            mysqlOptions => mysqlOptions.MigrationsAssembly("CallTrack.Data") // Nome do assembly das migrations
                        )
                );

            return builder;
        }

        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                //cfg.AddProfile(typeof(GetCallProfile));
                cfg.AddProfile(typeof(PostCallProfile));

            });

        //Validação das configurações do AutoMapper
        //var serviceProvider = services.BuildServiceProvider();
        //var mapperConfig = serviceProvider.GetRequiredService<AutoMapper.IConfigurationProvider>();
        //mapperConfig.AssertConfigurationIsValid();

        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            services.AddMediatR(cfg => 
                        cfg.RegisterServicesFromAssembly(Assembly.Load("CallTrack.Domain")));


            return services;
        }
    }
}
