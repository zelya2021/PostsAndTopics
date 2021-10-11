
using PostsAndTopics.Models;
using PostsAndTopics.Services.Interfaces;
using PostsAndTopics.Services.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsAndTopics.Services
{
    public class PostService: IPostService
    {
        private IRepositoryWrapper _repoWrapper;

        public PostService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<List<Post>> GetAllPostByTopicIdsAsync(long topicId)
        {
            return await Task.FromResult(_repoWrapper.Post.FindByCondition(x=>x.TopicId==topicId).ToList());
        }

        public bool IsPostAlreadyExist(Post topic)
        {
            return _repoWrapper.Post.FindByCondition(x => x.Thought == topic.Thought).FirstOrDefault() == null ? false : true;
        }

        public void CreatePostAsync(Post post)
        {
            _repoWrapper.Post.Create(post);
        }

        public void DeletePostById(int id)
        {
            _repoWrapper.Post.Delete(_repoWrapper.Post.FindByCondition(x => x.Id == id).FirstOrDefault());
        }

        public async Task<Post> GetPostByIdAsync(long id)
        {
            return await Task.FromResult(_repoWrapper.Post.FindByCondition(x => x.Id == id).FirstOrDefault());
        }

        public void EditPost(Post post)
        {
            _repoWrapper.Post.Update(post);
        }

    }
}

