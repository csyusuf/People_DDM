using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using People.Application.Interfaces;
using People.Application.Services;
using People.Domain.CommandHandlers;
using People.Domain.Commands;
using People.Domain.Core.Bus;
using People.Domain.Core.Notifications;
using People.Domain.Interfaces;
using People.Infrastructure.CrossCutting.Bus;
using People.Infrastructure.Data.Context;
using People.Infrastructure.Data.Repository;
using People.Infrastructure.Data.UoW;

namespace People.Infrastructure.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //// Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

           
            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IPersonAppService, PersonAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            //services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            //services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            //services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<INotificationHandler<CreateNewPersonCommand>, PersonCommandHandler>();
            services.AddScoped<INotificationHandler<UpdatePersonCommand>, PersonCommandHandler>();
            services.AddScoped<INotificationHandler<DeletePersonCommand>, PersonCommandHandler>();

            // Infra - Data
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<PeopleContext>();

            // Infra - Data EventSourcing
            //services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            //services.AddScoped<IEventStore, SqlEventStore>();
            //services.AddScoped<EventStoreSQLContext>();

        }
    }
}
