
// Config connection string in .net core 6
// https://stackoverflow.com/questions/68980778/config-connection-string-in-net-core-6

using Company.BL.Repositories;
using Company.BL.Services;
using Company.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DATABASE CONNECTION * (UseSqlServer -> EntityFrameworkCore)
// Inyectar el contexto en el contenedor de servicios mediante inyeccion de dependencias
// services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("cadena_conexion"));

builder.Services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DevConnection")
    ));


// CORS * AddPolicy("NameCors",policyBuilder)
builder.Services.AddCors(options => options.AddPolicy("AllowWebApp",
    policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
    ));


// INYECCIÓN DE DEPENDENCIAS * (Agregar database connection)
builder.Services.AddTransient<IUserRepository, UserService>();
builder.Services.AddTransient<IGameRepository, GameService>();

// CONVERTIR RUTAS EN MINÚSCULAS
builder.Services.AddRouting(routing => routing.LowercaseUrls = true);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS * app.UseCors("NameCors");
app.UseCors("AllowWebApp"); // Cors

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
