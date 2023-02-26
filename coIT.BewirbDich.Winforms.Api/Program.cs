using coIT.BewirbDich.Persistence;
using coIT.BewirbDich.Persistence.Interceptors;
using coIT.BewirbDich.Winforms.Infrastructure.BackgroundJobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Quartz;

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
                coIT.BewirbDich.Winforms.Infrastructure.AssemblyReference.Assembly,
                coIT.BewirbDich.Persistence.AssemblyReference.Assembly)
            .AddClasses(false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

string connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddMediatR(
    (sc) =>
    {
        sc.RegisterServicesFromAssemblies(coIT.BewirbDich.Winforms.Application.AssemblyReference.Assembly);
        sc.Lifetime = ServiceLifetime.Scoped;
    });

builder.Services.AddSingleton<ConvertDomainEventsToOutboxMessagesInterceptor>();
builder.Services.AddDbContext<ApplicationDbContext>(
    (sp, optionsBuilder) =>
    {
        var interceptor = sp.GetService<ConvertDomainEventsToOutboxMessagesInterceptor>();
        optionsBuilder.UseSqlServer(connectionString)
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