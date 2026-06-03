
using Microsoft.EntityFrameworkCore;
using SistemaFuncionarios.API.Middlewares;
using SistemaFuncionarios.Application.Services;
using SistemaFuncionarios.Domain.Interfaces;
using SistemaFuncionarios.Infrastructure.Data;
using SistemaFuncionarios.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();

builder.Services.AddScoped<FuncionarioService>();
builder.Services.AddScoped<DepartamentoService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope()) {
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();