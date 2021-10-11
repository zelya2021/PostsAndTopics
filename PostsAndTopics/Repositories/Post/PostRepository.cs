using PostsAndTopics.Models.Database;
using PostsAndTopics.Services.Repositories;
using PostsAndTopics.Models;

namespace PostsAndTopics.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(DatabaseContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
