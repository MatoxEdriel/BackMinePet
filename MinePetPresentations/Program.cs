using Infrastructure.Repositories;
using Application.UseCases;
using Application.UseCases.Auth;
using Domain.Interfaces;
using Domain.Interfaces.Repo;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Presentations.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MinePetContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>(); 



builder.Services.AddScoped<CreatePetUseCase>();
builder.Services.AddScoped<RegisterUser>();
builder.Services.AddScoped<LoginUser>();


builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") 
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
//Dependencias automapper 
//se debe crear mapeoso 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("AllowAngular");
app.UseAuthorization();
app.MapControllers();

app.Run();