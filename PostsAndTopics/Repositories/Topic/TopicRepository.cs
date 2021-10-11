using PostsAndTopics.Models;
using PostsAndTopics.Models.Database;
using PostsAndTopics.Services.Repositories;

namespace PostsAndTopics.Repositories
{
    public class TopicRepository : RepositoryBase<Topic>, ITopicRepository
    {
        public TopicRepository(DatabaseContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
