using CallTrack.Api.extensions;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner
builder.AddPersistence(); // Adiciona o contexto de dados ao contêiner
builder.Services.AddSwaggerGen(); // Adiciona as configurações do Swagger
builder.AddApiSwagger();// Adiciona a interface do swagger
builder.Services.AddSwagger();
var app = builder.Build();

var environment = app.Environment;
app.UseExceptionHandling(environment)
    .UseSwaggerMiddleware()
    .UseAppCors();

app.UseRateLimiting();// Aplica o Rate Limiting configurado no middleware

app.UseAuthentication();
app.UseAuthorization();

app.Run();
