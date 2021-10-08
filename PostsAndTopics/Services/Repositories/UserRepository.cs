using PostsAndTopics.Models;
using PostsAndTopics.Models.Database;

namespace PostsAndTopics.Services.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DatabaseContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
