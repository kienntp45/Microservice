using System.Reflection;

using AutoMapper.Extensions.ExpressionMapping;

using Iot.Class.Data;
using Iot.Core.Data.Relational.Repositories.Implements;
using Iot.Core.Data.Relational.Repositories.Interfaces;
using Iot.Core.DependencyInjection.Extensions;
using Iot.Core.EventBus.Configurations;
using Iot.Core.EventBus.Extensions.DependencyInjection;
using Iot.Core.EventStore.Configurations;
using Iot.Core.EventStore.Extensions.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Iot.Class.Infatructure.Extention.Dependency_Injection;

public static class ServiceColletionExtention
{
    public static IServiceCollection AddApplication(this IServiceCollection services, ConfigurationManager configuration)
    {
        using (var serviceProvider = services.BuildServiceProvider())
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var entryAssembly = Assembly.GetEntryAssembly();

            services.AddDependencies();
            services.AddAutoMapper(configuration =>
            {
                configuration.AddExpressionMapping();
            }, executingAssembly, entryAssembly);
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Default")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddEventStore(configuration.GetSection("EventStore").Get<EventStoreConfiguration>());
            services.AddEventBus(configuration.GetSection("EventBus").Get<EventBusConfiguration>());
            services.AddMediatR(executingAssembly, entryAssembly);

        }

        return services;
    }
}