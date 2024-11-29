using CallTrack.Api.extensions;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner
builder.AddPersistence();
builder.Services.AddSwaggerGen();
builder.AddApiSwagger();
builder.Services.AddSwagger();

var app = builder.Build();

// Configuração do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
