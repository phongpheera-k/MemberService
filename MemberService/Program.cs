using MemberService.Repository.Interfaces;
using MemberService.Repository.Repositories;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options => options.AddServerHeader = false);

builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json")
    .AddEnvironmentVariables();

builder.Host
    //.AddDiscoveryClient() //Steeltoe.Discovery.Consul
    .UseNLog();

// Add services to the container
var connectionString = builder.Configuration.GetConnectionString("Database")!;
builder.Services.AddSingleton<IMemberRepository>(_ => new MemberRepository(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();