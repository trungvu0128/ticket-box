using Newtonsoft.Json.Serialization;
using Project.Core.Extensions;
using Project.Middlewares;
using Project.ProcessLogical.MasterData.CostCenters;
using Project.ProcessLogical.Validators;
using Project.Repository.Commands.CostCenters;
using Serilog;
using Serilog.Core;
using Shared.ORM;
using Shared.ORM.Repositories;
using Shared.Tracking;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Logger logger = new LoggerConfiguration()
        .WriteTo.Console()
        //.WriteTo.File(defineAppSetting.ConfigOptions.LogConfig.LogPath, rollingInterval: RollingInterval.Day)
        .CreateLogger();

builder.Services.AddSingleton(logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add database service
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? string.Empty;
builder.Services.UseSQLServer(connectionString);

builder.Services
    .AddControllers()
    .AddJsonOptions(opt => opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    });

// Resolve register service to DI container
builder.Services.Resolve(new Assembly[] { typeof(ICostCenterCommand).Assembly, typeof(CostCenterAddLogic).Assembly });

builder.Services.AddSingleton<ITrackingLog, TrackingLog>();

builder.Services.AddScoped<IRepositoryTransaction, RepositoryTransaction>();

builder.Services.UseValidator();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
