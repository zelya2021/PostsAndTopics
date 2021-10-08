using Microsoft.Extensions.DependencyInjection;
using PostsAndTopics.Services.Repositories;

namespace PostsAndTopics.Services
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
