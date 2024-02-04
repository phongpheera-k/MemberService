using MemberService.Services.Services.Implements;
using MemberService.Services.Services.Interfaces;

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
builder.Services.AddScoped<IMemberAccountRepository>(_ => new MemberAccountRepository(connectionString));

builder.Services.AddScoped<IHashService, HashService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddTransient<ISignUpService, SignUpService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();