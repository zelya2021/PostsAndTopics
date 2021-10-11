using PostsAndTopics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostsAndTopics.Services.Interfaces
{
    public interface IPostService
    {
        Task<List<Post>> GetAllPostByTopicIdsAsync(long topicId);
        bool IsPostAlreadyExist(Post topic);
        void CreatePostAsync(Post post);
        Task<Post> GetPostByIdAsync(long id);
        void DeletePostById(int id);
        void EditPost(Post post);
    }
}
