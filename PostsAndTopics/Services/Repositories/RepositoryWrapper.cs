using PostsAndTopics.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsAndTopics.Services.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DatabaseContext _dbContext;
        private IUserRepository _user;
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_dbContext);
                }
                return _user;
            }
        }
        public RepositoryWrapper(DatabaseContext abContext)
        {
            _dbContext = abContext;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
