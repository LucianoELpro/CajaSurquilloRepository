using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Application.Interfaces;
using Application.Interfaces.Services;
using Persistence.Services;

namespace Persistence
{
    public static class ServiceExtension
    {
        public static void AddPersistenceService(this IServiceCollection service)
        {
            service.AddTransient(typeof(ICardRequestRepository), typeof(CardRequestRepository));
            service.AddTransient(typeof(IDataConnection), typeof(DataConnection));
            service.AddTransient(typeof(ITramarService), typeof(TramaService));
            service.AddTransient(typeof(ITramaPosition), typeof(TramaPositionService));
        }
    }
}
