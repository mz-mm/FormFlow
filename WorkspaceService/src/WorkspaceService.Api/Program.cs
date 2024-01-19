using Microsoft.EntityFrameworkCore;
using WorkspaceService.Domain.AsyncDataService;
using WorkspaceService.Domain.Services;
using WorkspaceService.Infrastructure.Contexts;
using WorkspaceService.Infrastructure.Interfaces;
using WorkspaceService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>(x => 
    new MessageBusClient(builder.Configuration, builder.Environment.IsProduction()));

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("WorkspacePgsqlConn")));
}
else
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING")));
}

builder.Services.AddScoped<IWorkspaceRepository, WorkspaceRepository>();
builder.Services.AddScoped<IWorkspaceService, WorkspaceService.Domain.Services.WorkspaceService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
