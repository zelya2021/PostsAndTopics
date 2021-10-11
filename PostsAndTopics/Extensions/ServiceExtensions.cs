using Microsoft.Extensions.DependencyInjection;
using PostsAndTopics.Services.Interfaces;
using PostsAndTopics.Services.Repositories;

namespace PostsAndTopics.Services
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IPostService, PostService>();
        }
    }
}
