using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SmartCamping.Models;
using SmartCampingAPI.Data;
using SmartCampingAPI.Interfaces;
using SmartCampingAPI.Repository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ITokenManager, TokenManager>();
builder.Services.AddControllers();
builder.Services.AddMvc()
        .AddNewtonsoftJson(
          options => {
              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          });
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAlojamentoRepository, AlojamentoRepository>();
builder.Services.AddScoped<IAlojamentoFotosRepository, AlojamentoFotosRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IEstadoReservaRepository, EstadoReservaRepository>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<IMetodoPagamentoRepository, MetodoPagamentoRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<ITipoAlojamentoRepository, TipoAlojamentoRepository>();
builder.Services.AddScoped<ITipoUtilizadorRepository, TipoUtilizadorRepository>();
builder.Services.AddScoped<IUtilizadorRepository, UtilizadorRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseCors();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
