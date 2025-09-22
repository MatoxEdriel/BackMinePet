using Infrastructure.Repositories;
using Application.UseCases;
using Application.UseCases.Auth;
using Domain.Interfaces;
using Domain.Interfaces.Repo;
using Domain.Interfaces.Services;
using Domain.Services;
using Infrastructure.context;
using Microsoft.EntityFrameworkCore;
using Presentations.middleware;
using Presentations.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MinePetContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddScoped<IPasswordService, BcrypPasswordService>();

builder.Services.AddScoped<ITokenService, JwtTokenService>();
    
    
builder.Services.AddScoped<RegisterUser>();
builder.Services.AddScoped<LoginUser>();


// builder.Services.AddScoped<IJwtService, JwtService>();
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



builder.Services.AddAutoMapper(
    typeof(Application.Mappings.AutoMapping).Assembly,
    typeof(Presentations.Mappings.PresentationMapping).Assembly
);


builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Introduce el token JWT con 'Bearer ' antes del valor",
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            []
        }
    });
});



var app = builder.Build();
app.UseMiddleware<ErrorHandle>();
app.MapGet("/", (HttpContext context) =>
{
    context.Response.Redirect("/swagger/index.html" , permanent:false );

});


app.UseSwagger(); 
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("AllowAngular");
app.UseAuthorization();
app.MapControllers();

app.Run();