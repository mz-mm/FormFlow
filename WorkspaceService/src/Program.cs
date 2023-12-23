using Microsoft.EntityFrameworkCore;
using src.Context;
using src.Repositories.Classes;
using src.Repositories.Interfaces;
using src.Services.Classes;
using src.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMem"));
builder.Services.AddScoped<IWorkspaceRepository, WorkspaceRepository>();
builder.Services.AddScoped<IWorkspaceService, WorkspaceService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseRouting();

app.Run();
