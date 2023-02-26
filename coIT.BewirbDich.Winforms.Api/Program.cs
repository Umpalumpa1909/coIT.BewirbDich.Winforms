using coIT.BewirbDich.Api.Middleware;
using coIT.BewirbDich.Application.Behaviors;
using coIT.BewirbDich.Infrastructure.BackgroundJobs;
using coIT.BewirbDich.Infrastructure.Idempotence;
using coIT.BewirbDich.Persistence;
using coIT.BewirbDich.Persistence.Interceptors;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Quartz;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.MapType<decimal>(() => new OpenApiSchema
    {
        Type = "number",
        Format = "decimal"
    });
    options.SchemaFilter<EnumerationToEnumSchemaFilter>();
});
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder
    .Services
    .Scan(
        selector => selector
            .FromAssemblies(
                coIT.BewirbDich.Infrastructure.AssemblyReference.Assembly,
                coIT.BewirbDich.Persistence.AssemblyReference.Assembly)
            .AddClasses(false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
var validatorAssemblies = new List<Assembly>() { coIT.BewirbDich.Application.AssemblyReference.Assembly };
builder.Services.AddValidatorsFromAssemblies(validatorAssemblies, includeInternalTypes: true);

//string connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddMediatR(
    (sc) =>
    {
        sc.RegisterServicesFromAssemblies(coIT.BewirbDich.Application.AssemblyReference.Assembly);

        sc.Lifetime = ServiceLifetime.Scoped;
    });

builder.Services.Decorate(typeof(INotificationHandler<>), typeof(IdempotentDomainEventHandler<>));

builder.Services.AddSingleton<ConvertDomainEventsToOutboxMessagesInterceptor>();
builder.Services.AddDbContext<ApplicationDbContext>(
    (sp, optionsBuilder) =>
    {
        var interceptor = sp.GetService<ConvertDomainEventsToOutboxMessagesInterceptor>()!;
        optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
        .AddInterceptors(interceptor);
    });

builder.Services.AddQuartz(configure =>
{
    var jobKey = new JobKey(nameof(ProcessOutboxMessagesJob));

    configure
        .AddJob<ProcessOutboxMessagesJob>(jobKey)
        .AddTrigger(
            trigger =>
                trigger.ForJob(jobKey)
                    .WithSimpleSchedule(
                        schedule =>
                            schedule.WithIntervalInSeconds(10)
                                .RepeatForever()));

    configure.UseMicrosoftDependencyInjectionJobFactory();
});
builder.Services.AddQuartzHostedService();
builder
    .Services
    .AddControllers()
    .AddApplicationPart(coIT.BewirbDich.Presentation.AssemblyReference.Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();