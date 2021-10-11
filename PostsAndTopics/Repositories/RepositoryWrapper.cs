using PostsAndTopics.Models.Database;
using PostsAndTopics.Repositories;
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
        private ITopicRepository _topic;
        private IPostRepository _post;
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

        public ITopicRepository Topic
        {
            get
            {
                if (_topic == null)
                {
                    _topic = new TopicRepository(_dbContext);
                }
                return _topic;
            }
        }

        public IPostRepository Post
        {
            get
            {
                if (_post == null)
                {
                    _post = new PostRepository(_dbContext);
                }
                return _post;
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
