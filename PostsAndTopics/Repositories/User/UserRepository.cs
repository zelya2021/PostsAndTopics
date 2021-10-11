using Microsoft.EntityFrameworkCore;
using PostsAndTopics.Models;
using PostsAndTopics.Models.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
