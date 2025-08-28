using Infrastructure.Repositories;
using Application.UseCases;
using Domain.Interfaces;
using Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MinePetContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Registrar repositorios e interfaces
builder.Services.AddScoped<IPetRepository, PetRepository>();

// Registrar Use Cases
builder.Services.AddScoped<CreatePetUseCase>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();