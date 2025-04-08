using Microsoft.EntityFrameworkCore;
using MSApiLoadCsvFiles.Data;
using MSApiLoadCsvFiles.Models;
using MSApiLoadCsvFiles.Repositories;
using MSApiLoadCsvFiles.Services;
using System.Runtime;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Added
builder.Services.AddScoped<IServUploadFile, ServUploadFile>();
builder.Services.AddScoped<IRepUploadFile, RepUploadFile> ();
builder.Services.AddScoped<IServAzureBlobStorage, ServAzureBlobStorage>();
builder.Services.AddScoped<ITriggerDFPipeline, TriggerDFPipeline>();


// Configure DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Configurar el acceso a la configuración
builder.Services.Configure<AzureSettings>(builder.Configuration.GetSection("AzureSettings"));

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
