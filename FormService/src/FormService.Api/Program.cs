using FormService.Domain.AsyncDataService;
using FormService.Domain.EventProcessing;
using FormService.Domain.Interfaces;
using FormService.Domain.Services;
using FormService.Infrastructure.Context;
using FormService.Infrastructure.Interfaces;
using FormService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddHostedService<MessageBusSubscriber>();
builder.Services.AddSingleton<IEventProcessor, EventProcessor>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IFormService, FormsService>();
builder.Services.AddScoped<IFormRepository, FormRepository>();

builder.Services.AddScoped<IFormQuestionService, FormQuestionService>();
builder.Services.AddScoped<IFormQuestionsRepository, FormQuestionRepository>();

builder.Services.AddScoped<IWorkspaceRepository, WorkspaceRepository>();
builder.Services.AddScoped<IWorkspaceService, WorkspaceService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING"),
        b => b.MigrationsAssembly("FormService.Infrastructure")));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
