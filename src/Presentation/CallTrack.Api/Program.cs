using CallTrack.Api.endpoints;
using CallTrack.Api.extensions;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner
builder.AddPersistence(); // Adiciona o contexto de dados ao contêiner
builder.Services.AddSwaggerGen(); // Adiciona as configurações do Swagger
builder.AddApiSwagger();// Adiciona a interface do swagger
builder.Services.AddSwagger();
builder.Services.AddDependencies();// Adiciona o serviço de injeção de dependeências
builder.Services.AddCors();
// Adicionando o Rate Limiter ao container de serviços
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("Fixed", limiterOptions =>
    {
        limiterOptions.PermitLimit = 10; // Limite de 10 requisições
        limiterOptions.Window = TimeSpan.FromSeconds(60); // Janela de tempo de 60 segundos
        limiterOptions.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
        limiterOptions.QueueLimit = 2; // Limite de 2 requisições em fila
    });
});
var app = builder.Build();

app.MapCallsEndpoints(); // Mapeia os endpoints da classe Call
app.MapReasonsEndpoints(); // Mapeia os endpoints da classe Re

var environment = app.Environment;
app.UseExceptionHandling(environment)
    .UseSwaggerMiddleware()
    .UseAppCors();

app.UseRateLimiting();// Aplica o Rate Limiting configurado no middleware

app.Run();
