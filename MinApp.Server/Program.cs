using MinApp.Core.Interfaces;
using MinApp.Server.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// CORS: tillad Blazor WASM klient (standard dev-port 5001 / 7xxx)
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorClient", policy =>
    {
        policy.WithOrigins(
                "https://localhost:7000",
                "http://localhost:5000",
                "https://localhost:7001",
                "http://localhost:5001")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Brug MockRepo under udvikling - skift til DbRepo for database
builder.Services.AddScoped<IRepo, MockRepo>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("BlazorClient");
app.UseAuthorization();
app.MapControllers();

app.Run();
