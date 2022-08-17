using MemberService.Repository.Dapper;
using MemberService.Repository.Interfaces;
using MemberService.Repository.Repositories;
using MemberService.Service.Interfaces;
using MemberService.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMemberMasterService, MemberMasterService>();
builder.Services.AddSingleton<IDatabaseDapperRepository, OracleDapperRepository>();
builder.Services.AddSingleton<IMemberMasterRepository, MemberMasterRepository>();
// builder.Services.AddSingleton<IMemberContactRepository, MemberContactRepository>();

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