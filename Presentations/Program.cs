using Infrastructure.Repositories;
using Application.UseCases;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MinePetContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IPetRepository, PetRepository>();

builder.Services.AddScoped<CreatePetUseCase>();

builder.Services.AddScoped<IUserRepository, UserRepository>(); 
builder.Services.AddScoped<RegisterUser>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();