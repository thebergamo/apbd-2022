using DoctorsAPI.Extensions;
using DoctorsAPI.Models;
using DoctorsAPI.Repositories;
using DoctorsAPI.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DoctorRepository>();
builder.Services.AddScoped<PrescriptionRepository>();
builder.Services.AddScoped<DoctorsService>();
builder.Services.AddScoped<PrescriptionsService>();

builder.Services.AddDbContext<MasterContext>(opt =>
{
    opt.LogTo(Console.WriteLine)
        .UseSqlServer(builder.Configuration.GetConnectionString("Default") ??
                      throw new InvalidOperationException("Please verify if ConnectionStrings.Default is set"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();