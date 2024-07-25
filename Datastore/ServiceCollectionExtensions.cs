using Microsoft.Extensions.DependencyInjection;

namespace Datastore;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatastore(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IDatastore, DatastoreImpl>();
        return serviceCollection;
    }
}