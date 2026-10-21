using AppControlVehiculos.AccesoDatos;
using AppControlVehiculos.Negocio.Implementaciones;
using AppControlVehiculos.Negocio.Interfaces;
using AppControlVehiculos.Repositorio.Implementacion;// ambas deben ser agregadas para que funcione la inyeccion de dependencias
using AppControlVehiculos.Repositorio.Interfaces;//
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DbAbb191BdvehiculosContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("cn"));
});

// Repositorios
builder.Services.AddScoped<IMarcaRepositorio, MarcaRepositorio>(); // Cuando algiuen solicite En IMarcaRepositorio                                                     // se le devolvera una instacia de MarcaRepositorio
builder.Services.AddScoped<IModeloRepositorio, ModeloRepositorio>();

// Negocios
builder.Services.AddScoped<IMarcaNegocio, MarcaNegocio>();
builder.Services.AddScoped<IModeloNegocio, ModeloNegocio>();

// Controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
