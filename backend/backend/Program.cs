using backend.Model;
using Microsoft.EntityFrameworkCore;
using backend.Services;
using backend.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddScoped<IEquipamentService, EquipamentService>();
builder.Services.AddScoped<ISituationService, SituationService>();

builder.Services.AddDbContext<DataBaseContext>(o => o.UseSqlServer(
    configuration.GetConnectionString("LocalDb")
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
    dbContext.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
