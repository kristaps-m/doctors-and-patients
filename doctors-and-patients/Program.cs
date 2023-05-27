using doctors_and_patients.Core;
using doctors_and_patients.Data;
using doctors_and_patients.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Register ! 
var connectionString = builder.Configuration.GetConnectionString("doctors-and-patients");
builder.Services.AddDbContext<DoctorsAndPatientsDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<IDoctorsAndPatientsDbContext, DoctorsAndPatientsDbContext>();
builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddScoped<IEntityService<Doctor>, EntityService<Doctor>>();
builder.Services.AddScoped<IEntityService<Patient>, EntityService<Patient>>();
builder.Services.AddScoped<IEntityService<DoctorPatient>, EntityService<DoctorPatient>>();
builder.Services.AddScoped<IDoctorService, DoctorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
