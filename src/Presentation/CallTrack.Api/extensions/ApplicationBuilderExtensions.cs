using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace CallTrack.Api.extensions;

public static class ApplicationBuilderExtensions
{
    //Metodo de extensão para tratamento de erros
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app,
           IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        return app;
    }
    //Metodo de extensão para habilitar e configurar o CORS
    public static IApplicationBuilder UseAppCors(this IApplicationBuilder app)
    {
        app.UseCors(p =>
        {
            p.AllowAnyOrigin(); //Permitir qualquer origem
            p.AllowAnyMethod(); // Métodos permitidos(Todos)
            p.AllowAnyHeader(); //Permitir qualquer cabeçalho
        });
        return app;
    }
    //Metodo de extensão para habilitar e configurar o RateLimiter
    public static IApplicationBuilder UseRateLimiting(this IApplicationBuilder app)
    {
        app.UseRateLimiter(new RateLimiterOptions
        {
            GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                RateLimitPartition.GetFixedWindowLimiter("DefaultPolicy", partition =>
                    new FixedWindowRateLimiterOptions
                    {
                        PermitLimit = 3, // Máximo de 3 requisições
                        Window = TimeSpan.FromSeconds(1), // Janela de 1 segundo
                        QueueLimit = 5, // Máximo de 5 requisições na fila
                        QueueProcessingOrder = QueueProcessingOrder.OldestFirst // Mais antigo primeiro
                    })),
            RejectionStatusCode = StatusCodes.Status429TooManyRequests // Código de status para rejeição
        });

        return app;
    }
    //Metodo de extensão para habilitar e configurar o Swagger
    public static IApplicationBuilder UseSwaggerMiddleware(this IApplicationBuilder app)
    {
        app.UseSwagger(); //Habilitar o Swagger
        app.UseSwaggerUI(c => { }); //Configurar o Swagger
        return app; //Retornar o app
    }
}
